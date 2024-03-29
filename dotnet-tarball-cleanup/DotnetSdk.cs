using System;
using System.IO;
using System.Linq;
using dotnet_tarball_cleanup.Extensions;
using McMaster.Extensions.CommandLineUtils;

namespace dotnet_tarball_cleanup
{
    public class DotnetSdk
    {
        private static string[] sdkResources = new[] { "host/fxr", "sdk" };
        private static string DOTNET_DIRECTORY = Path.GetDirectoryName(DotNetExe.FullPath);

        public static void Remove(string identifier, IConsole console)
        {
            var sdkFolders = sdkResources
                .Select(r => Path.Combine(DOTNET_DIRECTORY, r, identifier))
                .Where(Directory.Exists);

            if (!sdkFolders.Any())
            {
                console.WriteWithError($"No sdk version {identifier} installed ");
            }

            foreach (var folder in sdkFolders)
            {
                try
                {
                    console.Write($"Removing: {folder} ");
                    Directory.Delete(folder, true);
                    console.WriteWithCheck("Done!");
                }
                catch (Exception e)
                {
                    console.WriteWithError($"Error removing folder {folder} - Err: {e.Message}");
                }
            }

            console.WriteWithCheck($"Sdk {identifier} removed");
        }
    }
}