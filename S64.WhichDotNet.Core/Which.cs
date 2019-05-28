using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace S64.WhichDotNet.Core
{

    public sealed class Which
    {

        public IEnumerable<FileInfo> FindProgramFromPath(IEnumerable<DirectoryInfo> dirs, string program)
        {
            if (string.IsNullOrWhiteSpace(program))
            {
                return Enumerable.Empty<FileInfo>();
            }
            return dirs
                .Where(x => x.Exists)
                .Select(x => new FileInfo($"{x.FullName}{Pathes.DSC}{program}"))
                .Where(x => x.Exists);
        }

    }

}
