namespace EasyClip.Base
{
    public static class TextProcessUtil
    {
        /// <summary>
        /// Xử lý text: remove newline, trim, giới hạn độ dài.
        /// </summary>
        /// <param name="input">Text đầu vào</param>
        /// <param name="maxLength">Số ký tự tối đa cho phép</param>
        /// <param name="wasTrimmed">Out: true nếu text bị cắt</param>
        /// <returns>Text đã xử lý</returns>
        public static string ProcessText(string input, int maxLength, out bool wasTrimmed)
        {
            wasTrimmed = false;

            if (string.IsNullOrEmpty(input))
                return string.Empty;

            // Bỏ ký tự xuống dòng
            string processed = RemoveNewLineChars(input);

            // Trim khoảng trắng đầu cuối
            processed = processed.TrimStart();

            // Giới hạn độ dài
            if (processed.Length > maxLength)
            {
                processed = processed.Substring(0, maxLength);
                wasTrimmed = true;
            }

            return processed;
        }

        /// <summary>
        /// Xóa ký tự xuống dòng và nối text thành 1 dòng.
        /// </summary>
        private static string RemoveNewLineChars(string text)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;

            return text.Replace("\r", "").Replace("\n", " ");
        }
    }

}
