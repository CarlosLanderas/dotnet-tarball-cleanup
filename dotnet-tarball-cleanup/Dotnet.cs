using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;

namespace dotnet_tarball_cleanup
{
    public class Dotnet
    {
        private readonly IConsole _console;
        private string DOTNET_PATH = DotNetExe.FullPathOrDefault();

        public Dotnet(IConsole console)
        {
            _console = console;
        }

        public Task<DotnetResult> RunCommand(params string[] args)
        {
            var taskCompletionSource = new TaskCompletionSource<DotnetResult>();
            var result = new DotnetResult();

            var process = new Process
            {
                EnableRaisingEvents = true,
                StartInfo = new ProcessStartInfo
                {
                    FileName = DOTNET_PATH,
                    Arguments = String.Join(" ", args),
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    UseShellExecute = false
                }
            };

            process.ErrorDataReceived += (sender, args) =>
            {
                if (!string.IsNullOrEmpty(args.Data))
                {
                    result.AppendToStdError(args.Data);
                }
            };

            process.OutputDataReceived += (sender, args) =>
            {
                if (args != null)
                {
                    result.AppendToStdOutput(args.Data);
                }
            };

            process.Exited += (sender, eventArgs) =>
            {
                taskCompletionSource.SetResult(result);
            };

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            return taskCompletionSource.Task;
        }
    }
}