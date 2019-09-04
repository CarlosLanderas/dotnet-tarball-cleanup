using System;
using System.Text;

namespace dotnet_tarball_cleanup
{
    public class DotnetResult
    {
        public void AppendToStdError(string err) => StdError.AppendLine(err);

        public void AppendToStdOutput(string data) => StdOutput.AppendLine(data);

        public int ExitCode => StdError.Length == 0 ? 0 : -1;

        public Exception Exception => new Exception(StdError.ToString());

        public bool HasError => ExitCode != 0;

        internal StringBuilder StdError = new StringBuilder();

        internal StringBuilder StdOutput = new StringBuilder();

        public string Output => StdOutput.ToString();
    }
}