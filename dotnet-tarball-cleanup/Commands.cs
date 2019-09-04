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
    [Command(Name = "dotnet-tarball-cleanup", Description = "A global tool to clean SDKs and runtimes tarballs"),
     Subcommand(typeof(Sdks), typeof(Runtimes))]
    public class Commands
    {
        [Command("sdks", Description = "Manage installed Sdks"),
         Subcommand(typeof(List), typeof(Delete))]
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
                        console.WriteLine($"{sdk.version} ➡ {sdk.props}");
                    }
                }
               
            }
            [Command(Description = "Delete target Dotnet Sdk"), HelpOption]
            private class Delete
            {
                [Required(ErrorMessage = "You must specify the SDK version")]
                [Argument(0, Description = "SDK version")]
                public string Version { get; }

                private void OnExecute(IConsole console)
                {
                    console.WriteLine($"Removing sdk {Version}");
                }
            }
        }
        
        [Command("runtimes", Description = "Manage installed runtimes"),
         Subcommand(typeof(List), typeof(Delete))]
        private class Runtimes
        {
            [Command(Description = "List installed Dotnet Runtimes"), HelpOption]
            private class List
            {
                private async Task OnExecute(IConsole console)
                {
                    var installed = await DotnetPackages.Get(PackageType.Runtime, console);
                    console.WriteWithCheck("Installed runtimes");
                    foreach(var runtime in installed.GroupBy(x => x.version, (key, g) => new {package = key, pkgs = g.ToList().Select(g => g.props)}))
                    {
                        console.WriteLine($"{runtime.package} ➡ [{String.Join(" | ", runtime.pkgs)}]");
                    }
                }
               
            }
            [Command(Description = "Delete target Dotnet runtime"), HelpOption]
            private class Delete
            {
                [Required(ErrorMessage = "You must specify the SDK version")]
                [Argument(0, Description = "SDK version")]
                public string Version { get; }

                private void OnExecute(IConsole console)
                {
                    console.WriteLine($"Removing sdk {Version}");
                }
            }
        }
    }
}