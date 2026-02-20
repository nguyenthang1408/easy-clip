# Validate Character Usage - Bảo mật Voice Key & Xác thực ký tự

## Tổng quan

Hệ thống bảo mật cho việc ghi nhận số lượng ký tự sử dụng TTS (Text-to-Speech) và bảo vệ voice key khỏi bị lộ khi client bị crack.

### Vấn đề gốc

1. **Character count dễ fake**: Client tự report `characterCount` → hacker gửi `characterCount = 1` dù dùng hàng trăm ký tự
2. **Voice key bị lộ qua network**: Response trả raw key dạng plaintext → Charles Proxy / mitmproxy bắt được ngay
3. **Hardcoded limit**: Giới hạn ký tự per-request (400/500) hardcode trong code, không linh hoạt

### Giải pháp đã implement

| # | Giải pháp | Mục đích |
|---|-----------|----------|
| 1 | **AES-256-GCM encrypt voice key** | Chống sniff network, casual cracker |
| 2 | **Server-side character counting** | Server đếm chars → không fake được |
| 3 | **Gộp flow vào endpoint `/usage/tts`** | Đếm chars + ghi log + trả encrypted key trong 1 request |
| 4 | **Dynamic config từ ApiSecurity** | Thay đổi limit mà không deploy lại |

---

## Kiến trúc

### Endpoints

```
POST /api/v1/VoiceKeys/current      → Load config + encrypted voice key (mở app)
POST /api/v1/VoiceKeys/usage/tts    → Đếm chars + ghi usage log + encrypted voice key (bấm Đọc)
```

### Flow chính

```
Bước 1: Mở app
  Client → POST /api/v1/VoiceKeys/current { appCode, productSlug }
  Server ← { isSuccess, voiceKey: "encrypted...", keyTs, keyVersion, allowedLanguages, ... }
  Client: decrypt(voiceKey) → cache, hiển thị languages/voices

Bước 2: Mỗi lần bấm "Đọc"
  Client → POST /api/v1/VoiceKeys/usage/tts { appCode, productSlug, text: "Xin chào", source: "app1" }
  Server:
    1. Validate device + subscription
    2. Lấy voice key (cached, KHÔNG mutate)
    3. Check limit: daily, package, per-request (dynamic config)
    4. Đếm text.Length → 8 chars (SERVER đếm, không tin client)
    5. Ghi CharacterUsageLog (IsVerified = true)
    6. Encrypt voice key → AES-256-GCM
  Server ← {
    success, responseMsgCode, isWarning,
    voiceType, providerName, voiceKey: "encrypted...", keyTs, keyVersion,
    characterUsed, characterLimit, dailyCharacterUsed, dailyCharacterLimit,
    characterCount: 8
  }
  Client: decrypt(voiceKey) → gọi TTS provider (Google Cloud / ElevenLabs / FPT AI)
```

---

## API Reference

### 1. POST /api/v1/VoiceKeys/current

Lấy encrypted voice key + config. Dùng khi mở app hoặc load lại config. **KHÔNG ghi character usage.**

**Request:**
```json
{
  "appCode": "RCF50ACE26NU3M",
  "productSlug": "easy-clip1"
}
```

| Field | Type | Required | Mô tả |
|-------|------|----------|--------|
| `appCode` | string | Yes | Mã thiết bị |
| `productSlug` | string | No | Product slug (default: `"default-voice-tool"`) |

**Response (success):**
```json
{
  "error": false,
  "message": null,
  "code": 200,
  "data": {
    "isSuccess": true,
    "unlimit": true,
    "voiceType": "googlecloud",
    "providerName": "google cloud1",
    "packageId": "PKG_BASIC_001",
    "keyName": "key #1",
    "keyId": 1,
    "voiceKey": "NvLuaPAkjWhqM4/SxyuWNmCQ2VyIru7d/shth1WRHg==",
    "keyTs": 1770402802,
    "keyVersion": "v1",
    "assignedAt": "2026-02-04T16:38:53.3700892",
    "activeUsers": 1,
    "maxActiveUsers": 10,
    "allowedLanguages": [],
    "allowedTotalVoices": 9999,
    "characterUsed": 230695,
    "characterLimit": 140000000,
    "dailyCharacterUsed": 3,
    "dailyCharacterLimit": null
  }
}
```

**Handler:** `GetVoiceKeyHandler.cs`
**Response DTO:** `VoiceKeyResponseDto.cs`

### 2. POST /api/v1/VoiceKeys/usage/tts

API kết hợp: server đếm ký tự + ghi usage log + trả encrypted voice key. Dùng mỗi lần user bấm "Đọc".

**Request:**
```json
{
  "appCode": "RCF50ACE26NU3M",
  "productSlug": "easy-clip1",
  "text": "tôi là toàn 123",
  "source": "app1"
}
```

| Field | Type | Required | Mô tả |
|-------|------|----------|--------|
| `appCode` | string | Yes | Mã thiết bị |
| `productSlug` | string | No | Product slug (default: `"default-voice-tool"`) |
| `text` | string | Yes | Text gốc cần đọc TTS. Server đếm `text.Length` |
| `source` | string | No | Platform identifier (max 64 chars) |

**Response (success):**
```json
{
  "error": false,
  "message": "Character usage logged successfully.",
  "code": 200,
  "data": {
    "success": true,
    "responseMsgCode": 2000,
    "isWarning": false,
    "voiceType": "googlecloud",
    "providerName": "google cloud1",
    "keyName": "key #1",
    "keyId": 1,
    "voiceKey": "RyJSn2/540fYGoGcw7S2izRsiUzMoV02+m5BqQ20wA==",
    "keyTs": 1770400837,
    "keyVersion": "v1",
    "characterUsed": 230302,
    "characterLimit": 140000000,
    "dailyCharacterUsed": 30,
    "dailyCharacterLimit": null,
    "characterCount": 15
  }
}
```

| Response Field | Type | Mô tả |
|----------------|------|--------|
| `success` | bool | `true` nếu ghi usage thành công |
| `responseMsgCode` | int | Response code (xem bảng bên dưới) |
| `isWarning` | bool | `true` nếu chars > 80% MaxCharactersPerSecond |
| `voiceType` | string | Loại TTS provider (e.g., `"googlecloud"`) |
| `providerName` | string | Tên provider hiển thị |
| `keyName` | string | Tên voice key |
| `keyId` | long | ID voice key |
| `voiceKey` | string | Voice key đã encrypt AES-256-GCM |
| `keyTs` | long | Unix timestamp dùng derive decryption key |
| `keyVersion` | string | Version encryption key (hỗ trợ key rotation) |
| `characterUsed` | long | Tổng ký tự đã dùng (monthly, đã cộng request hiện tại) |
| `characterLimit` | long? | Giới hạn ký tự/tháng (null = không giới hạn) |
| `dailyCharacterUsed` | long | Ký tự đã dùng hôm nay (đã cộng request hiện tại) |
| `dailyCharacterLimit` | int? | Giới hạn ký tự/ngày (null = không giới hạn) |
| `characterCount` | int | Số ký tự server đếm từ `text` lần này |

**Response (error - ví dụ vượt limit):**
```json
{
  "error": true,
  "message": "Character count (1500) exceeds the maximum limit of 1000 characters.",
  "code": 4004,
  "data": null
}
```

**Handler:** `TtsUsageHandler.cs`
**Request DTO:** `TtsUsageRequest.cs`
**Response DTO:** `TtsUsageResponseDto.cs`

---

## Chi tiết kỹ thuật

### 1. Voice Key Encryption (AES-256-GCM)

**Thuật toán derive key (server & client giống nhau):**

```
Input:
  salt     = "T2P-VoiceKey-..."  (config trên server, hardcode obfuscated trong app)
  userId   = "guid-xxx"          (client biết từ login)
  keyTs    = 1738857600          (server trả trong response)

Derive:
  decryptionKey = HMAC-SHA256(salt_bytes, userId + "|" + keyTs)
  → Output: 32 bytes = AES-256 key

Encrypt (server):
  IV = random 12 bytes (GCM nonce)
  AES-256-GCM(voiceKeyPlain, decryptionKey, IV) → ciphertext + authTag
  Output = Base64(IV[12] + ciphertext[N] + authTag[16])

Decrypt (client):
  1. Base64 decode → tách IV(12), ciphertext(N-28), tag(16)
  2. Derive cùng key bằng salt + userId + keyTs
  3. AES-256-GCM decrypt
```

**Files:**
- `Application/Interfaces/IVoiceKeyEncryptionService.cs` - Interface
- `Application/UseCases/VoiceKey/Services/VoiceKeyEncryptionService.cs` - Implementation

**Config (appsettings.json):**
```json
{
  "VoiceKeyEncryption": {
    "Salt": "CHANGE-THIS-IN-PRODUCTION-MUST-MATCH-CLIENT",
    "KeyVersion": "v1"
  }
}
```

**Bảo mật:**
- Hacker sniff network → chỉ thấy ciphertext, không có raw key
- Hacker decompile app → phải tìm salt trong code đã obfuscate
- Mỗi lần gọi → ciphertext khác nhau (random nonce)
- `keyVersion` hỗ trợ rotate salt mà không break client cũ

**Lưu ý quan trọng - Cached object:**
- `GetActiveAssignedKeyForUserAndProductAsync()` trả về **cached object** (2-5 phút)
- Handler **KHÔNG được mutate** cached object trực tiếp
- Phải copy sang response DTO mới rồi mới encrypt/modify trên đó

### 2. Server-side Character Counting

**Trước:** Client tự report `characterCount` → dễ fake
**Sau:** Client gửi `text` → server đếm `text.Length` → ghi log với `IsVerified = true`

**Trong TtsUsageHandler:**
- Client gửi `text` (required) → server đếm `text.Length`
- Ghi `CharacterUsageLog` với `IsVerified = true` (server tự đếm, không tin client)
- Response trả `characterUsed` và `dailyCharacterUsed` đã cộng thêm chars vừa dùng

### 3. Dynamic Character Limit (từ ApiSecurity Config)

**Trước:** Hardcoded `if (charCount > 500) reject`
**Sau:** Lấy từ config: `MaxCharactersPerSecond` trong Admin > ApiSecurity > GlobalSettings > Throttling tab

```csharp
var config = await _security.GetEffectiveConfigAsync(endpoint);
var maxCharsPerRequest = config.MaxCharactersPerSecond; // dynamic, default 1000
var warningThreshold = (int)(maxCharsPerRequest * 0.8); // cảnh báo tại 80%
```

- Nếu `characterCount > maxCharsPerRequest` → reject (code 4004)
- Nếu `characterCount > warningThreshold` → success nhưng `isWarning = true` (code 2001)
- Thay đổi limit qua Admin UI (Admin > ApiSecurity), không cần deploy lại

---

## Database

### CharacterUsageLogs - Cột `IsVerified`

```sql
ALTER TABLE CharacterUsageLogs
ADD IsVerified BIT NOT NULL DEFAULT 0;
```

| Giá trị | Ý nghĩa |
|---------|---------|
| `true` | Character count do server đếm (tin cậy) - từ `/usage/tts` |
| `false` | Character count do client report (không tin cậy) - dữ liệu cũ |

**Migration:** `20260206080000_AddIsVerifiedToCharacterUsageLogs.cs`

**Query audit:**
```sql
-- Tìm request không verified (có thể bị fake - dữ liệu cũ)
SELECT * FROM CharacterUsageLogs WHERE IsVerified = 0;

-- So sánh verified vs unverified usage per user
SELECT AppUserId,
       SUM(CASE WHEN IsVerified = 1 THEN CharacterCount ELSE 0 END) AS VerifiedChars,
       SUM(CASE WHEN IsVerified = 0 THEN CharacterCount ELSE 0 END) AS UnverifiedChars
FROM CharacterUsageLogs
GROUP BY AppUserId;
```

---

## Response Codes (CharacterUsageResponseCodes)

Dùng cho endpoint `/usage/tts`. Defined tại `Contract/DTO/CharacterUsageResponseCodes.cs`.

| Code | Name | HTTP | Mô tả | Frontend action |
|------|------|------|--------|-----------------|
| 2000 | `SUCCESS_NORMAL` | 200 | Thành công, ký tự bình thường | Hiển thị success |
| 2001 | `SUCCESS_WITH_WARNING` | 200 | Thành công nhưng gần đạt giới hạn (>80%) | Hiển thị warning badge |
| 4001 | `ERROR_DEVICE_NOT_FOUND` | 404 | Device không tồn tại | Yêu cầu đăng nhập lại |
| 4002 | `ERROR_NO_VOICE_KEY` | 404 | User chưa được gán voice key | Hiển thị "chưa kích hoạt" |
| 4003 | `ERROR_INVALID_CHARACTER_COUNT` | 400 | Text không hợp lệ (empty/null) | Validation error |
| 4004 | `ERROR_EXCEEDS_LIMIT` | 400 | Vượt MaxCharactersPerSecond per-request | Block, hiển thị error |
| 4005 | `ERROR_DAILY_LIMIT_EXCEEDED` | 429 | Hết lượt hàng ngày | "Hết lượt hôm nay" |
| 4006 | `ERROR_PACKAGE_LIMIT_EXCEEDED` | 429 | Hết lượt gói | "Nâng cấp gói" |
| 5000 | `ERROR_INTERNAL` | 500 | Lỗi server | "Thử lại sau" |

---

## Files hiện tại

| File | Mô tả |
|------|--------|
| `Application/Interfaces/IVoiceKeyEncryptionService.cs` | Interface encrypt voice key |
| `Application/UseCases/VoiceKey/Services/VoiceKeyEncryptionService.cs` | AES-256-GCM encryption |
| `Application/UseCases/VoiceKey/Requests/GetVoiceKeyRequest.cs` | Request DTO cho `/current` (appCode, productSlug) |
| `Application/UseCases/VoiceKey/Handlers/GetVoiceKeyHandler.cs` | Handler cho `/current` |
| `Application/UseCases/VoiceKey/Requests/TtsUsageRequest.cs` | Request DTO cho `/usage/tts` (appCode, productSlug, text, source) |
| `Application/UseCases/VoiceKey/Handlers/TtsUsageHandler.cs` | Handler cho `/usage/tts` |
| `Application/ViewModels/VoiceKey/VoiceKeyResponseDto.cs` | Response DTO cho `/current` |
| `Application/ViewModels/VoiceKey/TtsUsageResponseDto.cs` | Response DTO cho `/usage/tts` |
| `Contract/DTO/CharacterUsageResponseCodes.cs` | Response codes (2000-4006, 5000) |
| `Domain/Entities/Voice/VoiceManager.cs` | Entity `CharacterUsageLog` |
| `Persistence/Migrations/20260206080000_AddIsVerifiedToCharacterUsageLogs.cs` | EF Migration |
| `Web/Controllers/API/ReviewTool/V1/VoiceKeysController.cs` | Controller (2 endpoints) |
| `Web/Startup.cs` | DI registration `IVoiceKeyEncryptionService` |

---

## Hướng dẫn cho Client

### Decrypt voice key (pseudo-code)

```
function decryptVoiceKey(encryptedBase64, userId, keyTs, salt):
    // 1. Derive key
    message = userId + "|" + keyTs
    aesKey = HMAC_SHA256(salt_bytes, message_bytes)  // 32 bytes

    // 2. Decode
    data = Base64Decode(encryptedBase64)
    iv         = data[0..11]        // 12 bytes
    ciphertext = data[12..N-16]     // N-28 bytes
    authTag    = data[N-16..N]      // 16 bytes

    // 3. Decrypt
    plaintext = AES_256_GCM_Decrypt(ciphertext, aesKey, iv, authTag)
    return UTF8_ToString(plaintext)  // raw voice key
```

### Client flow

```
// Mở app - load config
response = POST /api/v1/VoiceKeys/current { appCode, productSlug }
languages = response.data.allowedLanguages
rawKey = decryptVoiceKey(response.data.voiceKey, userId, response.data.keyTs, SALT)

// Bấm đọc - gửi text + nhận encrypted key + ghi usage
response = POST /api/v1/VoiceKeys/usage/tts { appCode, productSlug, text: userText, source: "app1" }
if (response.data.success) {
    rawKey = decryptVoiceKey(response.data.voiceKey, userId, response.data.keyTs, SALT)
    audio = callTTS(rawKey, userText, selectedVoice)
    // Cập nhật UI: characterUsed, dailyCharacterUsed, isWarning
} else {
    // Xử lý error theo responseMsgCode
}
```

---

## Config Production Checklist

- [ ] Đổi `VoiceKeyEncryption:Salt` trong `appsettings.Production.json` (>= 32 chars, match với client)
- [ ] Nhúng salt vào native code của client app (C++/Rust qua JNI/FFI)
- [ ] Bật certificate pinning trên client
- [ ] Set `MaxCharactersPerSecond` phù hợp trong Admin > ApiSecurity > Throttling
