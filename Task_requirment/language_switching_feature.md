# Task: Chuyển Đổi Ngôn Ngữ (Language Switching)

## 1. Hiện trạng

App hiện tại có text **tiếng Việt và tiếng Anh lẫn lộn**, tất cả đều hardcode trực tiếp trong:

| Vị trí | Mô tả | Ví dụ |
|--------|-------|-------|
| `LoginApiKey.Designer.cs` | Button, Label, LinkLabel, Form title | `"ĐĂNG NHẬP"`, `"Trợ Giúp"`, `"Đăng Ký"` |
| `LoginApiKey.cs` | MessageBox, status text | `"Vui lòng nhập API Key!"`, `"Đăng nhập thành công!"` |
| `FormMain.Designer.cs` | ~70+ controls (Label, Button, GroupBox, MenuItem, ToolStrip...) | `"Chuyển Đổi Text -> Voice"`, `"Ghép Video"`, `"Cài Đặt Voice"` |
| `FormMain.cs` | ~60+ MessageBox, status text, dynamic text | `"Nhập Đường Dẫn & Khởi Tạo Project !"`, `"Tạo Project Thành Công !"` |
| `FormLoadingCancel.Designer.cs` | Label | `"Đang huỷ... vui lòng chờ"` |
| `Program.cs` | MessageBox | `"Ứng dụng đã chạy..."` |
| `VersionMessageHelper.cs` | Dictionary thông báo server | `"Đăng nhập thành công!"`, `"API Key không hợp lệ..."` |
| `GpuDetectionMessages.cs` | ~30 const string messages | `"GPU NVIDIA không khả dụng!"`, `"Vui lòng cập nhật driver..."` |

**Tổng ước lượng: ~180+ chuỗi text cần dịch.**

---

## 2. Mong muốn

- **2 ngôn ngữ**: Tiếng Việt (vi) & Tiếng Anh (en)
- Chọn ngôn ngữ ngay tại **màn Login**
- Áp dụng **toàn bộ app** (tất cả Form, MessageBox, status text, error messages)
- Ngôn ngữ được **lưu lại** (lần mở sau nhớ lựa chọn)

---

## 3. Hướng tiếp cận đề xuất

### 3.1 Kiến trúc: `LanguageManager` + Dictionary Resource

Sử dụng pattern **Static LanguageManager** với dictionary key-value cho từng ngôn ngữ. Lý do chọn cách này thay vì .resx:
- App dùng MaterialSkin controls (không phải standard WinForms) -> `.resx` localization tự động của WinForms **không hoạt động tốt** với MaterialSkin
- Code hiện tại text nằm cả trong code-behind (MessageBox, dynamic text) chứ không chỉ Designer -> cần quản lý tập trung
- Dễ maintain, dễ thêm ngôn ngữ mới trong tương lai

### 3.2 Cấu trúc file mới

```
ReviewMovie/
├── Localization/
│   ├── LanguageManager.cs          # Core: quản lý ngôn ngữ hiện tại, get translation
│   ├── ILocalizable.cs             # Interface cho Form implement
│   ├── LangKeys.cs                 # Const string keys (tránh typo)
│   ├── Resources/
│   │   ├── Lang_vi.cs              # Dictionary tiếng Việt
│   │   └── Lang_en.cs              # Dictionary tiếng Anh
```

### 3.3 Chi tiết thiết kế

#### `LanguageManager.cs`
```csharp
public static class LanguageManager
{
    public enum Language { Vi, En }

    public static Language CurrentLanguage { get; private set; } = Language.Vi;
    public static event Action LanguageChanged; // Notify all forms

    public static void SetLanguage(Language lang)
    {
        CurrentLanguage = lang;
        SaveLanguageSetting(lang);
        LanguageChanged?.Invoke();
    }

    public static string Get(string key)
    {
        var dict = CurrentLanguage == Language.Vi ? Lang_vi.Texts : Lang_en.Texts;
        return dict.TryGetValue(key, out var val) ? val : $"[{key}]";
    }

    // Load/Save từ Properties.Settings
    public static void LoadSavedLanguage() { ... }
    private static void SaveLanguageSetting(Language lang) { ... }
}
```

#### `ILocalizable.cs`
```csharp
public interface ILocalizable
{
    void ApplyLanguage(); // Mỗi form implement để cập nhật text
}
```

#### `LangKeys.cs` (ví dụ)
```csharp
public static class LangKeys
{
    // Login Form
    public const string Login_Title = "Login_Title";
    public const string Login_BtnLogin = "Login_BtnLogin";
    public const string Login_Help = "Login_Help";
    public const string Login_Register = "Login_Register";
    public const string Login_EnterApiKey = "Login_EnterApiKey";
    public const string Login_Success = "Login_Success";
    // ... 180+ keys

    // Main Form
    public const string Main_Title = "Main_Title";
    public const string Main_CreateProject = "Main_CreateProject";
    // ...
}
```

#### `Lang_vi.cs` / `Lang_en.cs`
```csharp
public static class Lang_vi
{
    public static readonly Dictionary<string, string> Texts = new Dictionary<string, string>
    {
        { LangKeys.Login_Title, "REVIEW_MOVIE LOGIN" },
        { LangKeys.Login_BtnLogin, "ĐĂNG NHẬP" },
        { LangKeys.Login_Help, "Trợ Giúp" },
        // ...
    };
}
```

### 3.4 Thay đổi UI - Màn Login

Thêm **ComboBox chọn ngôn ngữ** vào `LoginApiKey`:
```
┌─────────────────────────────────────┐
│  [🌐 Tiếng Việt ▼]    REVIEW_MOVIE │
│                                     │
│  APP CODE                           │
│  ┌─────────────────────────────┐    │
│  │ ABC-123-XYZ                 │    │
│  └─────────────────────────────┘    │
│  API KEY                            │
│  ┌─────────────────────────────┐    │
│  │ ****                        │    │
│  └─────────────────────────────┘    │
│  _                                  │
│  [  ĐĂNG NHẬP  ]    Đăng Ký        │
│                      Trợ Giúp       │
└─────────────────────────────────────┘
```

- ComboBox ở **góc trên trái** màn Login
- Options: `"Tiếng Việt"` / `"English"`
- Khi chọn -> thay đổi ngôn ngữ ngay lập tức (cả màn Login lẫn các form sau)

### 3.5 Lưu ngôn ngữ

Sử dụng `Properties.Settings.Default` (có sẵn trong project) để lưu language setting:
- `Properties.Settings.Default.Language = "vi"` hoặc `"en"`
- Load lại khi app khởi động

---

## 4. Phạm vi thay đổi

| File | Thay đổi |
|------|----------|
| **Mới** `Localization/LanguageManager.cs` | Core language manager |
| **Mới** `Localization/ILocalizable.cs` | Interface |
| **Mới** `Localization/LangKeys.cs` | Key constants |
| **Mới** `Localization/Resources/Lang_vi.cs` | Vietnamese translations |
| **Mới** `Localization/Resources/Lang_en.cs` | English translations |
| `LoginApiKey.cs` | Thêm ComboBox, implement `ILocalizable` |
| `LoginApiKey.Designer.cs` | Thêm ComboBox control |
| `FormMain.cs` | Implement `ILocalizable`, thay thế hardcode text bằng `LanguageManager.Get()` |
| `FormMain.Designer.cs` | Remove hardcode text (set trong ApplyLanguage) |
| `FormLoadingCancel.cs` | Implement `ILocalizable` |
| `Program.cs` | Thay thế hardcode MessageBox text |
| `VersionMessageHelper.cs` | Refactor để hỗ trợ 2 ngôn ngữ |
| `GpuDetectionMessages.cs` | Refactor để hỗ trợ 2 ngôn ngữ |
| `Properties/Settings.settings` | Thêm Language setting |

---

## 5. Quy trình thực hiện

1. Tạo cấu trúc `Localization/` và các file core
2. Scan toàn bộ codebase, thu thập tất cả text -> tạo `LangKeys.cs`
3. Tạo `Lang_vi.cs` (giữ nguyên text hiện tại) và `Lang_en.cs` (dịch sang English)
4. Thêm ComboBox ngôn ngữ vào `LoginApiKey`
5. Implement `ILocalizable` cho từng Form
6. Thay thế tất cả hardcode text bằng `LanguageManager.Get(LangKeys.xxx)`
7. Refactor `VersionMessageHelper.cs` và `GpuDetectionMessages.cs`
8. Thêm Language setting vào `Properties.Settings`
9. Test toàn bộ flow

---

## 6. Lưu ý

- **Không thay đổi logic nghiệp vụ** - chỉ thay đổi text hiển thị
- **Giữ nguyên layout** - chỉ thêm ComboBox ngôn ngữ ở Login
- Text format có biến (`$"Bạn đang sử dụng phiên bản {currentVersion}..."`) sẽ dùng `string.Format()` với placeholder
- Một số text kỹ thuật (tên button "Save", "Record", "Render Part") có thể giữ nguyên tiếng Anh ở cả 2 ngôn ngữ nếu phù hợp

---

## 7. Tiến độ thực hiện (Progress Log)

### Đợt 0: Core infrastructure + UI Forms (Hoàn thành)
- Tạo `Localization/LanguageManager.cs`, `ILocalizable.cs`, `LangKeys.cs`
- Tạo `Localization/Resources/Lang_vi.cs`, `Lang_en.cs`
- Localize `LoginApiKey.cs/.Designer.cs` - form đăng nhập + ComboBox ngôn ngữ
- Localize `FormMain.cs/.Designer.cs` - form chính (~130 keys)
- Localize `FormLoadingCancel.cs` - loading dialog
- Localize `Program.cs` - startup messages
- Localize `VersionMessageHelper.cs` - API response messages (delegate pattern)
- Localize `GpuDetectionMessages.cs` - GPU detection messages
- Thêm `Language` setting vào `Properties.Settings`

### Đợt 1: Services + LibCommon nhóm CAO & TRUNG BÌNH (Hoàn thành)

**Hạ tầng mới:**
- Tạo `LibCommon/Lib/Localization/LibLocalizer.cs` - static localizer cho LibCommon (delegate pattern, wire up từ Program.cs)

**42 chuỗi đã localize, 12 files thay đổi:**

| File | Số chuỗi | Mô tả |
|------|----------|-------|
| `ReviewMovie/Services/AudioConvertService.cs` | 12 | Convert text-to-speech: status, lỗi, huỷ |
| `ReviewMovie/Services/AudioDownloadService.cs` | 5 | Download/record audio: thành công, thất bại |
| `ReviewMovie/Services/AudioRecordService.cs` | 5 | Ghi âm: status, lỗi |
| `ReviewMovie/Services/VideoMergeService.cs` | 1 | Ghép video: progress |
| `ReviewMovie/Services/ClipPlayerService.cs` | 1 | ClipPlayer not found |
| `ReviewMovie/Services/Popup/LoadingService.cs` | 1 | "Đang xử lý..." default text |
| `ReviewMovie/Base/CustomTextBox.cs` | 1 | Placeholder text |
| `LibCommon/Lib/VoiceServices/GoogleTTS/APIGoogleTTS.cs` | 7 | Validation + result messages |
| `LibCommon/Lib/Constant/Component.cs` | 6 | Effect names + zoom ratio labels |
| `LibCommon/Lib/Constant/EffectConfig.cs` | 2 | Config names (Mặc Định / Tùy Chỉnh) |
| `LibCommon/Lib/Model/Package/PackageType.cs` | 1 | Package display "{N} tháng/months" |
| `ReviewMovie/Program.cs` | 0 | Wire up `LibLocalizer.GetText = LanguageManager.Get` |

**Keys mới thêm vào LangKeys.cs:** `Svc_*` (26 keys) + `Lib_*` (16 keys) = 42 keys

**Kỹ thuật:**
- ReviewMovie/Services: dùng trực tiếp `LanguageManager.Get()` / `LanguageManager.GetFormat()`
- LibCommon: dùng `LibLocalizer.Get()` / `LibLocalizer.GetFormat()` (delegate wired trong Program.cs)
- Component.cs / EffectConfig.cs: đổi `const string` → `static string` property (getter gọi `LibLocalizer.Get()`)

### Đợt 2: Voice Display Names nhóm THẤP (Hoàn thành)

**Hạ tầng bổ sung:**
- Thêm `GetCurrentLanguage` delegate + `IsEnglish` property vào `LibLocalizer.cs`
- Wire `LibLocalizer.GetCurrentLanguage` trong `Program.cs`

**~109 chuỗi đã localize, 3 files thay đổi:**

| File | Số chuỗi | Mô tả |
|------|----------|-------|
| `LibCommon/Lib/VoiceServices/GoogleTTS/GoogleTTSVoiceCode.cs` | 63 | Tên ngôn ngữ (2 dictionary Vi/En, chọn theo `LibLocalizer.IsEnglish`) |
| `LibCommon/Lib/VoiceServices/Vbee/VbeeVoiceCode.cs` | 36 | 12 tên ngôn ngữ + 9 giọng VN + 10 giọng UK + 5 giọng US |
| `LibCommon/Lib/VoiceServices/FptAI/FptAIVoiceCode.cs` | 10 | 1 tên ngôn ngữ + 9 giọng VN |

**Kỹ thuật:**
- GoogleTTSVoiceCode: 2 dictionaries (`LanguageMapVi` / `LanguageMapEn`), `GetLanguageDisplayName()` chọn map theo ngôn ngữ
- VbeeVoiceCode / FptAIVoiceCode: đổi `const string _Des` → `static string _Des` property với ternary `LibLocalizer.IsEnglish ? "EN" : "VI"`
- Chỉ đổi các _Des field có text tiếng Việt; giữ nguyên tên quốc tế (Brune, Akemi, Moon, etc.)

---

### Tổng kết toàn bộ

| Đợt | Số chuỗi | Files changed |
|-----|----------|---------------|
| Đợt 0 (Core + UI) | ~180 | 15 files |
| Đợt 1 (Services + LibCommon CAO/TB) | 42 | 12 files |
| Đợt 2 (Voice display names) | 109 | 3 files |
| **Tổng** | **~331** | **~30 files** |

---

## 8. Bug Fixes

### Fix #1: T2Psoft voice source không lưu đúng khi save/reload project (Hoàn thành)

**Triệu chứng:** Chọn T2Psoft → save project → mở lại → combobox nhảy sang Google/FptAI/Elevenlab.

**Nguyên nhân gốc:**

T2Psoft là proxy, server trả về `VoiceType` cho biết sub-engine thực tế (Google/FPT/Elevenlab). Trong `HandleT2PsoftVoiceSource()` (FormMain.cs ~line 773-799):

```
User chọn T2Psoft → server trả VoiceType="Google"
→ _manualSelected = ManualSelect.Google
→ UpdateVoiceSourceSelect() lưu _infoProject.VoiceSelect = "Google"
→ Lần sau load project → FindIndex match "Google" → combobox chọn GoogleTTS (sai!)
```

`ManualSelect` enum trước đó không có giá trị `T2Psoft`, nên không thể lưu đúng nguồn đã chọn.

**Data flow liên quan:**

| Thành phần | File | Vai trò |
|------------|------|---------|
| `InfoProject.VoiceSelect` | `ProjectModel.cs` | Field string lưu tên voice source |
| `ManualSelect` enum | `Enum.cs` | Enum các voice source, trước thiếu T2Psoft |
| `ListVoiceSite` constants | `AISiteSource.cs` | Hằng số tên site: "T2Psoft", "FptAI", "Google", "Elevenlab", "Vbee" |
| `ProjectDataService` | `ProjectDataService.cs` | Lưu/đọc project vào LiteDB tại `{ProjectPath}\{ProjectID}.db` |
| `ConfigDataService` | `ConfigDataService.cs` | Lưu danh sách project vào `%AppData%\EasyClip\config.db` |
| `HandleT2PsoftVoiceSource()` | `FormMain.cs` ~line 730-805 | Xử lý khi chọn T2Psoft, gọi API server lấy sub-engine |
| `UpdateVoiceSourceSelect()` | `FormMain.cs` ~line 4910 | Lưu VoiceSelect vào DB khi thay đổi |
| `GetVoiceSourcesByPackageType()` | `FormMain.cs` ~line 659-699 | Tạo danh sách voice source cho combobox theo package type |
| `btnOpenProject_Click` | `FormMain.cs` ~line 3930-3976 | Load project và restore combobox voice source |

**Cách fix (3 thay đổi):**

1. **`LibCommon/Lib/Constant/Enum.cs`** — Thêm `T2Psoft` vào `ManualSelect` enum:
   ```csharp
   public enum ManualSelect
   {
       FptAI = 0,
       Vbee,
       Google,
       Elevenlab,
       T2Psoft    // ← MỚI
   }
   ```

2. **`ReviewMovie/FormMain.cs`** — Thêm helper `GetCurrentVoiceSourceName()`:
   ```csharp
   private string GetCurrentVoiceSourceName()
   {
       var selectedVoiceSource = (ComboboxModel)cboSiteNguon.SelectedItem;
       if (selectedVoiceSource?.Value == ListVoiceSite.T2Psoft)
           return ListVoiceSite.T2Psoft;
       return _manualSelected.ToString();
   }
   ```
   Helper này kiểm tra combobox `cboSiteNguon`: nếu đang chọn T2Psoft thì trả "T2Psoft", ngược lại trả `_manualSelected.ToString()`.

3. **`ReviewMovie/FormMain.cs`** — Dùng helper thay `_manualSelected.ToString()` tại 2 điểm persistence:
   - `UpdateVoiceSourceSelect()` (~line 4913): `_infoProject.VoiceSelect = GetCurrentVoiceSourceName();`
   - `CreateNewProject()` call (~line 4227): `_loadConfig.CreateNewProject(path, GetCurrentVoiceSourceName(), ...)`

**Lý do không đổi `_manualSelected` trong `HandleT2PsoftVoiceSource`:**

`_manualSelected` vẫn giữ sub-engine (Google/FptAI/Elevenlab) vì nó được dùng ở nhiều nơi cho logic TTS engine routing:
- `cbLanguageSelect_SelectedIndexChanged` (~line 4012-4094): load danh sách voice theo engine
- `theart_SaveSpeechAsync` (~line 2195-2236): xác định cách download audio
- `AudioConvertContextModel.ManualSelected` (~line 1804): truyền vào service convert
- `cbxSpeechType_SelectedIndexChanged` (~line 4102): cài đặt Elevenlab-specific

Nếu set `_manualSelected = T2Psoft` thì tất cả if-else ở trên sẽ không match → TTS engine routing hỏng. Fix chỉ tách phần **persistence** ra helper riêng, giữ nguyên phần **engine routing**.
