using System;
using System.Diagnostics;

namespace Lib
{
    public partial class Funcion
    {
        public static void OpenFolder(string folderPath)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = folderPath,
                UseShellExecute = true, // Quan trọng trên .NET Core
                Verb = "open"
            };
            Process.Start(startInfo);
        }
    }
}
