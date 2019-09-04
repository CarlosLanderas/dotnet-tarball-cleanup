using System;
using System.IO;
using System.Linq;
using dotnet_tarball_cleanup.Extensions;
using McMaster.Extensions.CommandLineUtils;

namespace dotnet_tarball_cleanup
{
    public class DotnetRuntime
    {
        private static string[] runtimeResources = new[] {"shared"};
        
        public static void Remove(string version, string identifier, IConsole console)
        {
            var directory = Path.GetDirectoryName(DotNetExe.FullPath);

            var runtimeFolders = runtimeResources
                .Select(r => Path.Combine(directory, r, identifier))
                .Where(Directory.Exists);

            foreach (var folder in runtimeFolders)
            {
                var runtimePath = Path.Combine(folder, version);
                if (Directory.Exists(runtimePath))
                {
                    try
                    {
                        console.Write($"Removing: {runtimePath} ");
                        Directory.Delete(runtimePath, true);
                        console.WriteWithCheck("Done!");
                    }
                    catch (Exception e)
                    {
                        console.WriteWithError($"Error removing folder {runtimePath}");
                    }
                }
            }
        }

    }
}