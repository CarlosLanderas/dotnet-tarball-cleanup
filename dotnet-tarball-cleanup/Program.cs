using System;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;

namespace dotnet_tarball_cleanup
{
    class Program
    {
        public static int Main(string[] args)
        {
            return CommandLineApplication.Execute<Commands>(args);
        }
    }
}