using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using dotnet_tarball_cleanup.Extensions;
using McMaster.Extensions.CommandLineUtils;

namespace dotnet_tarball_cleanup
{
    [Command(Name = "dotnet-tarball-cleanup", Description = ".NET Core global tool to list and remove SDKs and runtimes tarballs installed with dotnet-install scripts"),
     Subcommand(typeof(Sdks), typeof(Runtimes))]
    public class Commands
    {
        [Command("sdks", Description = "Manage installed Sdks"),
         Subcommand(typeof(List), typeof(Remove))]
        private class Sdks
        {
            [Command(Description = "List installed Dotnet Sdks"), HelpOption]
            private class List
            {
                private async Task OnExecute(IConsole console)
                {
                    var installed = await DotnetPackages.Get(PackageType.Sdk, console);

                    console.WriteWithCheck("Installed SDKs");
                    foreach (var sdk in installed)
                    {
                        console.WriteLine($"{sdk.props} ➡ {sdk.version}");
                    }
                }
            }

            [Command(Description = "Remove target Dotnet Sdk"), HelpOption]
            private class Remove
            {
                [Option(Description = "You must specify the SDK version")]
                public string Version { get; }
                
                [Option(Description = "Remove all installed SDKs")]
                public bool All { get; }

                private async Task OnExecute(IConsole console)
                {
                    if (!All)
                    {
                       RemoveSdk(Version, console);
                       return;
                    }
                    
                    var installed = await DotnetPackages.Get(PackageType.Sdk, console);
                    foreach (var sdk in installed)
                    {
                        RemoveSdk(sdk.props, console);
                    }
                }

                private void RemoveSdk(string identifier, IConsole console)
                {
                    console.WriteLine($"Looking for sdk {identifier}");
                    DotnetSdk.Remove(identifier, console);
                }
            }
        }

        [Command("runtimes", Description = "Manage installed runtimes"),
         Subcommand(typeof(List), typeof(Remove))]
        private class Runtimes
        {
            [Command(Description = "List installed Dotnet Runtimes"), HelpOption]
            private class List
            {
                private async Task OnExecute(IConsole console)
                {
                    var installed = await DotnetPackages.Get(PackageType.Runtime, console);
                    console.WriteWithCheck("Installed runtimes");
                    foreach (var runtime in installed.GroupBy(
                        x => x.version, (key, g) => new
                        {
                            package = key,
                            pkgs = g.ToList().Select(g => g.props)
                        }))
                    {
                        console.WriteLine($"{runtime.package} ➡ [{String.Join(" | ", runtime.pkgs)}]");
                    }
                }
            }

            [Command(Description = "Remove target Dotnet runtime"), HelpOption]
            private class Remove
            {
                [Option(Description = "You must specify the Runtime version")]
                public string Version { get; }
                
                [Option(Description = "Removes all installed runtimes")]
                public bool All { get; }

                private async Task OnExecute(IConsole console)
                {
                    var installed = await DotnetPackages.Get(PackageType.Runtime, console);
                    
                    if (!All)
                    {
                        var target = installed.FirstOrDefault(i => i.version == Version);
                        if (target.version == default)
                        {
                            console.WriteWithError($"Runtime version {Version} was not found");
                        }
                        removeRuntime(target.version, target.props, console);
                        return;
                    }
                    
                    
                    foreach (var runtime in installed)
                    {
                        removeRuntime(runtime.version, runtime.props, console);
                    }
                }

                private void removeRuntime(string identifier, string version, IConsole console)
                {
                    console.WriteLine($"Looking for runtime {identifier}");
                    DotnetRuntime.Remove(identifier, version, console);
                }
            };
        }
    }
}

