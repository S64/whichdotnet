using System;
using McMaster.Extensions.CommandLineUtils;
using S64.WhichDotNet.Core;

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

        [Option("--show-dot", CommandOptionType.NoValue)]
        bool ShotDot { get; }

        [Option("--show-tilde", CommandOptionType.NoValue)]
        bool ShowTilde { get; }

        [Option("-s", CommandOptionType.NoValue)]
        bool S { get; }

        [Option("--skip-winreg", CommandOptionType.NoValue)]
        bool SkipWinreg { get; }

        [Option("--with-nonexecutable", CommandOptionType.NoValue)]
        bool WithNonExecutable { get; }

        static void Main(string[] args)
            => CommandLineApplication.Execute<Program>(args);

        void OnExecute()
        {

        }

    }

}
