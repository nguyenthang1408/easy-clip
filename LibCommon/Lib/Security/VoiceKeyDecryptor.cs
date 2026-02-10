using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace LibCommon.Lib.Security
{
    /// <summary>
    /// Giải mã voice key được mã hóa bằng AES-256-GCM từ server.
    /// Sử dụng Windows BCrypt API (P/Invoke) vì .NET Framework 4.8 không có AesGcm built-in.
    ///
    /// Flow:
    ///   1. Derive key: HMAC-SHA256(salt_bytes, userId + "|" + keyTs) → 32 bytes
    ///   2. Base64 decode encrypted data → IV(12) + ciphertext(N-28) + authTag(16)
    ///   3. AES-256-GCM decrypt → plaintext voice key
    /// </summary>
    public static class VoiceKeyDecryptor
    {
        private const string SALT = "CHANGE-THIS-TO-A-STRONG-SALT-IN-PRODUCTION-MUST-MATCH-CLIENT";

        /// <summary>
        /// Giải mã voice key từ response server
        /// </summary>
        /// <param name="encryptedBase64">Voice key đã mã hóa (Base64)</param>
        /// <param name="userId">Email user (dùng làm userId để derive key)</param>
        /// <param name="keyTs">Unix timestamp từ server response</param>
        /// <returns>Plain text voice key</returns>
        public static string Decrypt(string encryptedBase64, string userId, long keyTs)
        {
            if (string.IsNullOrEmpty(encryptedBase64))
                throw new ArgumentException("Encrypted voice key is empty");
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("UserId is empty");

            // 1. Derive AES-256 key: HMAC-SHA256(salt, userId + "|" + keyTs)
            byte[] saltBytes = Encoding.UTF8.GetBytes(SALT);
            byte[] messageBytes = Encoding.UTF8.GetBytes(userId + "|" + keyTs);
            byte[] aesKey;
            using (var hmac = new HMACSHA256(saltBytes))
            {
                aesKey = hmac.ComputeHash(messageBytes);
            }

            // 2. Base64 decode
            byte[] data = Convert.FromBase64String(encryptedBase64);
            if (data.Length < 28) // 12 (IV) + 0 (min ciphertext) + 16 (tag)
                throw new CryptographicException("Invalid encrypted data: too short");

            // 3. Split: IV(12) + ciphertext(N-28) + authTag(16)
            byte[] nonce = new byte[12];
            byte[] tag = new byte[16];
            int ciphertextLen = data.Length - 28;
            byte[] ciphertext = new byte[ciphertextLen];

            Buffer.BlockCopy(data, 0, nonce, 0, 12);
            Buffer.BlockCopy(data, 12, ciphertext, 0, ciphertextLen);
            Buffer.BlockCopy(data, data.Length - 16, tag, 0, 16);

            // 4. AES-256-GCM decrypt
            byte[] plaintext = AesGcmDecrypt(ciphertext, aesKey, nonce, tag);
            return Encoding.UTF8.GetString(plaintext);
        }

        #region Windows BCrypt AES-GCM

        private static byte[] AesGcmDecrypt(byte[] ciphertext, byte[] key, byte[] nonce, byte[] tag)
        {
            IntPtr hAlg = IntPtr.Zero;
            IntPtr hKey = IntPtr.Zero;

            try
            {
                CheckStatus(BCryptOpenAlgorithmProvider(out hAlg, BCRYPT_AES_ALGORITHM, null, 0));

                byte[] chainMode = Encoding.Unicode.GetBytes(BCRYPT_CHAIN_MODE_GCM + "\0");
                CheckStatus(BCryptSetProperty(hAlg, BCRYPT_CHAINING_MODE, chainMode, chainMode.Length, 0));

                CheckStatus(BCryptGenerateSymmetricKey(hAlg, out hKey, IntPtr.Zero, 0, key, key.Length, 0));

                var authInfo = new BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO();
                authInfo.cbSize = Marshal.SizeOf(typeof(BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO));
                authInfo.dwInfoVersion = 1; // BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO_VERSION

                GCHandle nonceHandle = GCHandle.Alloc(nonce, GCHandleType.Pinned);
                GCHandle tagHandle = GCHandle.Alloc(tag, GCHandleType.Pinned);

                try
                {
                    authInfo.pbNonce = nonceHandle.AddrOfPinnedObject();
                    authInfo.cbNonce = nonce.Length;
                    authInfo.pbTag = tagHandle.AddrOfPinnedObject();
                    authInfo.cbTag = tag.Length;

                    byte[] plaintext = new byte[ciphertext.Length];
                    int resultLen;
                    CheckStatus(BCryptDecrypt(hKey, ciphertext, ciphertext.Length, ref authInfo,
                        null, 0, plaintext, plaintext.Length, out resultLen, 0));

                    if (resultLen != plaintext.Length)
                        Array.Resize(ref plaintext, resultLen);

                    return plaintext;
                }
                finally
                {
                    nonceHandle.Free();
                    tagHandle.Free();
                }
            }
            finally
            {
                if (hKey != IntPtr.Zero) BCryptDestroyKey(hKey);
                if (hAlg != IntPtr.Zero) BCryptCloseAlgorithmProvider(hAlg, 0);
            }
        }

        private static void CheckStatus(uint status)
        {
            if (status != 0)
                throw new CryptographicException($"BCrypt failed: 0x{status:X8}");
        }

        #endregion

        #region BCrypt P/Invoke

        private const string BCRYPT_AES_ALGORITHM = "AES";
        private const string BCRYPT_CHAIN_MODE_GCM = "ChainingModeGCM";
        private const string BCRYPT_CHAINING_MODE = "ChainingMode";

        [StructLayout(LayoutKind.Sequential)]
        private struct BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO
        {
            public int cbSize;
            public int dwInfoVersion;
            public IntPtr pbNonce;
            public int cbNonce;
            public IntPtr pbAuthData;
            public int cbAuthData;
            public IntPtr pbTag;
            public int cbTag;
            public IntPtr pbMacContext;
            public int cbMacContext;
            public int cbAAD;
            public long cbData;
            public int dwFlags;
        }

        [DllImport("bcrypt.dll", CharSet = CharSet.Unicode)]
        private static extern uint BCryptOpenAlgorithmProvider(
            out IntPtr phAlgorithm, string pszAlgId, string pszImplementation, uint dwFlags);

        [DllImport("bcrypt.dll", CharSet = CharSet.Unicode)]
        private static extern uint BCryptSetProperty(
            IntPtr hObject, string pszProperty, byte[] pbInput, int cbInput, uint dwFlags);

        [DllImport("bcrypt.dll")]
        private static extern uint BCryptGenerateSymmetricKey(
            IntPtr hAlgorithm, out IntPtr phKey, IntPtr pbKeyObject, int cbKeyObject,
            byte[] pbSecret, int cbSecret, uint dwFlags);

        [DllImport("bcrypt.dll")]
        private static extern uint BCryptDecrypt(
            IntPtr hKey, byte[] pbInput, int cbInput,
            ref BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO pPaddingInfo,
            byte[] pbIV, int cbIV, byte[] pbOutput, int cbOutput,
            out int pcbResult, uint dwFlags);

        [DllImport("bcrypt.dll")]
        private static extern uint BCryptDestroyKey(IntPtr hKey);

        [DllImport("bcrypt.dll")]
        private static extern uint BCryptCloseAlgorithmProvider(IntPtr hAlgorithm, uint dwFlags);

        #endregion
    }
}
