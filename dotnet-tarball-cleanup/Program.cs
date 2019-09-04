using System;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;

namespace dotnet_tarball_cleanup
{
    class Program
    {
        public static int Main(string[] args)
        {
            var app = new CommandLineApplication<Commands>();
            app.Conventions.UseDefaultConventions();
            return app.Execute(args);
        }
    }
}