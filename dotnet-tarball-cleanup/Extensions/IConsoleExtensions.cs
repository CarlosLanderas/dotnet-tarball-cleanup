using System;
using McMaster.Extensions.CommandLineUtils;

namespace dotnet_tarball_cleanup.Extensions
{
    public static class IConsoleExtensions
    {
        public static void WriteWithCheck(this IConsole console, string text)
        {
            console.Write($"{text} ");
            console.ForegroundColor = ConsoleColor.Green;
            console.Write('✔');
            console.WriteLine("");
            console.ResetColor();
        }

        public static void WriteWithError(this IConsole console, string text)
        {
            console.Write($"{text} ");
            console.ForegroundColor = ConsoleColor.Red;
            console.Write('❗');
            console.WriteLine("");
            console.ResetColor();
        }
    }
}