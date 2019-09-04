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
    }
}