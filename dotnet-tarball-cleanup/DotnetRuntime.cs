using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using dotnet_tarball_cleanup.Extensions;
using McMaster.Extensions.CommandLineUtils;

namespace dotnet_tarball_cleanup
{
    public class DotnetRuntime
    {
        private static string DOTNET_DIRECTORY = Path.GetDirectoryName(DotNetExe.FullPath);
        private static string[] runtimeResources = new[] { "shared" };
    
        public static void RemoveWithRegex(string regex, IConsole console)
        {
            var runtimeFolders = runtimeResources
                .Select(r => Path.Combine(DOTNET_DIRECTORY, r))
                .SelectMany(r => Directory.GetDirectories(r));

            foreach (var runtimeFolder in runtimeFolders)
            {
                var versionDirs = runtimeFolders.SelectMany(rd => Directory.GetDirectories(rd));
                foreach (var version in versionDirs )
                {
                    if(Regex.IsMatch(version, regex))
                    {
                        RemoveDirectory(version, console );
                    }    
                }
            }

        }
        public static void Remove(string version, string identifier, IConsole console)
        {
            var runtimeFolders = runtimeResources
                .Select(r => Path.Combine(DOTNET_DIRECTORY, r, identifier))
                .Where(Directory.Exists);

            foreach (var folder in runtimeFolders)
            {
                var runtimePath = Path.Combine(folder, version);
                if (Directory.Exists(runtimePath))
                {
                  RemoveDirectory(runtimePath, console);
                }
            }
        }

        private static void RemoveDirectory(string runtimePath, IConsole console)
        {
            try
            {
                console.Write($"Removing: {runtimePath} ");
                Directory.Delete(runtimePath, true);
                console.WriteWithCheck("Done!");
            }
            catch (Exception e)
            {
                console.WriteWithError($"Error removing folder {runtimePath} - Err: {e.Message}");
            }
        }

    }
}