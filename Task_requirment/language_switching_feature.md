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
