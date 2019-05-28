using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace S64.WhichDotNet.Core
{

    public sealed class Which
    {

        public static IEnumerable<FileInfo> FindPrograms(string program, bool skipDot = false, bool skipTilde = false)
        {
            return FindProgramsFromPath(
                Paths.GetOrderedPathDirectories(skipDot: skipDot, skipTilde: skipTilde),
                program
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

    }

}
