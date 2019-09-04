using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using dotnet_tarball_cleanup.Extensions;
using McMaster.Extensions.CommandLineUtils;

namespace dotnet_tarball_cleanup
{
    public enum PackageType
    {
        Sdk,
        Runtime
    }
    
    public class DotnetPackages
    {
        private static IDictionary<PackageType, string> commands = new Dictionary<PackageType, string>
        {
            [PackageType.Sdk] = "--list-sdks",
            [PackageType.Runtime] = "--list-runtimes"
        };
        
        private static string[] sdkResources = new[] {"host/fxr", "sdk"};
        private static string[] runtimeResources = new[] {"shared"};

        
        public static async Task<IEnumerable<(string version, string props)>> Get(PackageType type, IConsole console)
        {
            var dotnet = new Dotnet(console);

            var result = await dotnet.RunCommand(commands[type]);

            if (result.HasError)
            {
                result.Error(console);
            }
            
            return DotnetParser.GetPackages(result.Output);
        }

        public static void RemoveSdk(string identifier, IConsole console)
        {
            var directory = Path.GetDirectoryName(DotNetExe.FullPath);

            var sdkFolders = sdkResources
                .Select(r => Path.Combine(directory, r, identifier))
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
                    console.WriteWithError($"Error removing folder {folder}");
                }
            }
            
            console.WriteWithCheck($"Sdk {identifier} removed");
        }

        public static void RemoveRuntime(string version, string identifier, IConsole console)
        {
            var directory = Path.GetDirectoryName(DotNetExe.FullPath);
            
        }

    }
}