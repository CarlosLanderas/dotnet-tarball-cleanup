using System;
using McMaster.Extensions.CommandLineUtils;

namespace dotnet_tarball_cleanup.Extensions
{
    public static class DotnetResultExtensions
    {
        public static void Error(this DotnetResult result, IConsole console)
        {
            console.WriteWithError(result.Exception.Message);
            Environment.Exit(result.ExitCode);
        }
    }
}