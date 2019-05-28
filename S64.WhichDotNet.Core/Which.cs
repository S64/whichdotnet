using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using S64.WhichDotNet.WinExt;

namespace S64.WhichDotNet.Core
{

    public sealed class Which
    {

        public static IEnumerable<FileInfo> FindPrograms(string program, bool skipDot = false, bool skipTilde = false, bool skipWinReg = false)
        {
            return Enumerable.Concat(
                skipWinReg ? Enumerable.Empty<FileInfo>() : FindProgramsFromPlatformReg(),
                FindProgramsFromPath(
                    Paths.GetOrderedPathDirectories(skipDot: skipDot, skipTilde: skipTilde),
                    program
                )
            );
        }

        public static IEnumerable<FileInfo> FindProgramsFromPath(IEnumerable<DirectoryInfo> dirs, string program)
        {
            if (string.IsNullOrWhiteSpace(program))
            {
                return Enumerable.Empty<FileInfo>();
            }
            return dirs
                .Where(x => x.Exists)
                .Select(x => new FileInfo($"{x.FullName}{Paths.DSC}{program}"))
                .Where(x => x.Exists);
        }

        public static IEnumerable<FileInfo> FindProgramsFromPlatformReg()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return AppPathRegs.GetOrderedRegPaths()
                    .Where(x => x.Exists);
            }
            return Enumerable.Empty<FileInfo>();
        }

    }

}
