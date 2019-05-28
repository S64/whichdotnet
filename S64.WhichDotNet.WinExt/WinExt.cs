using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32;
using System.Linq;

namespace S64.WhichDotNet.WinExt
{

    public sealed class WinExt
    {

        private static List<RegistryKey> Keys
        {
            get { return new List<RegistryKey> { Registry.CurrentUser, Registry.LocalMachine } }
        }

        public static IEnumerable<FileInfo> GetRegPaths()
        {
            var items = new List<FileInfo>();

            foreach (var root in Keys)
            {
                using (var paths = OpenSubKey(root))
                {
                    foreach (var keyName in paths.GetSubKeyNames())
                    {
                        using (var item = paths.OpenSubKey(keyName))
                        {
                            if (item.GetValue("") is string programPath && !string.IsNullOrWhiteSpace(programPath))
                            {
                                items.Add(new FileInfo(programPath));
                            }
                        }
                    }
                }
            }

            return items;
        }

        private static RegistryKey OpenSubKey(RegistryKey key)
        {
            return key.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\App Paths");
        }

    }

}
