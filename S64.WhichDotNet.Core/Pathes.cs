using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace S64.WhichDotNet.Core
{

    public sealed class Pathes
    {

        private static readonly char PathSeparator
            = IsWindows ? ';' : ':';

        private static string PathEnv
        {
            get { return Environment.GetEnvironmentVariable("PATH"); }
        }

        private static readonly bool IsWindows
            = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

    }

}
