using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections.Generic;

namespace S64.WhichDotNet.Core
{

    public sealed class Paths
    {

        private static readonly char PathSeparator
            = IsWindows ? ';' : ':';

        private static string PathEnv
        {
            get { return Environment.GetEnvironmentVariable("PATH"); }
        }

        private static readonly bool IsWindows
            = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        public static readonly char DSC
                    = Path.DirectorySeparatorChar;

        public static readonly DirectoryInfo HomeDir
            = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));

        public static IEnumerable<DirectoryInfo> GetOrderedPathDirectories(bool skipDot = false, bool skipTilde = false)
        {
            return PathEnv.Split(PathSeparator)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Where(x => !skipDot || x.IndexOf(".", StringComparison.Ordinal) != 0)
                .Where(x => !skipTilde || x.IndexOf("~", StringComparison.Ordinal) != 0)
                .Select(x => new DirectoryInfo(x));
        }

    }

}
