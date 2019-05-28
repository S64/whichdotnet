using System;
using McMaster.Extensions.CommandLineUtils;
using S64.WhichDotNet.Core;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace S64.WhichDotNet
{

    class Program
    {

        [Argument(0, Name = "program")]
        string ProgramName { get; }

        [Option("--all|-a", CommandOptionType.NoValue)]
        bool All { get; }

        [Option("--skip-dot", CommandOptionType.NoValue)]
        bool SkipDot { get; }

        [Option("--skip-tilde", CommandOptionType.NoValue)]
        bool SkipTilde { get; }

        /*
        [Option("--show-dot", CommandOptionType.NoValue)]
        bool ShotDot { get; }
        */

        [Option("--show-tilde", CommandOptionType.NoValue)]
        bool ShowTilde { get; }

        [Option("-s", CommandOptionType.NoValue)]
        bool S { get; }

        [Option("--skip-winreg", CommandOptionType.NoValue)]
        bool SkipWinreg { get; }

        /*
        [Option("--with-nonexecutable", CommandOptionType.NoValue)]
        bool WithNonExecutable { get; }
        */

        static void Main(string[] args)
            => CommandLineApplication.Execute<Program>(args);

        void OnExecute()
        {
            var results = Which.FindPrograms(ProgramName, skipDot: SkipDot, skipTilde: SkipTilde, skipWinReg: SkipWinreg)
                .ToList();

            if (S)
            {
                Environment.Exit(results.Count == 0 ? 1 : 0);
                return;
            }

            List<FileInfo> output = All ? results : results.Take(1).ToList();

            foreach (var item in output)
            {
                if (ShowTilde && item.FullName.IndexOf(Paths.HomeDir.FullName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    Console.WriteLine(
                        $"~{item.FullName.Remove(0, Paths.HomeDir.FullName.Length)}"
                    );
                }
                else
                {
                    Console.WriteLine(item.FullName);
                }
            }
        }

    }

}
