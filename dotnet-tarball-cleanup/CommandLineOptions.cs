using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;

namespace dotnet_tarball_cleanup
{
    [Command(
        Name = "dotnet-tarball-cleanup",
        FullName = "Dotnet Tarball Cleanup",
        Description = "Global tool for SDK and Runtime tarballs cleanup"
    )]
    [HelpOption]
    public class CommandLineOptions
    {
        private LogLevel? _logLevel;
        
        [Option("-p|--path <DIR>", Description = "Dotnet installation path")]
        [DirectoryExists]
        public string DotnetPath { get; }
        
        [Option("-s|--sdks", CommandOptionType.NoValue, Description = "List dotnet installed SDKs")]
        public bool ListSdks { get; }
        [Option("-r|--runtimes", CommandOptionType.NoValue, Description = "List dotnet installed SDKs")]
        public bool ListRuntimes { get; }
        
        [Option("-rm-sdk|--remove-sdk")]
        public string SdkVersion { get; }
        
        [Option("-rm-rt|--remove-runtime")]
        public string Runtimeversion { get; }
        
    }
}