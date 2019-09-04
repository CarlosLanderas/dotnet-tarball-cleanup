using System;
using System.Text;

namespace dotnet_tarball_cleanup
{
    public class DotnetResult
    {
        public StringBuilder StdError = new StringBuilder();
        public StringBuilder StdOutput = new StringBuilder();

        public Exception Exception => new Exception(StdError.ToString());
        
        public int ExitCode => StdError.Length == 0 ? 0 : -1;
        public string Output => StdOutput.ToString();
        public bool HasError => ExitCode != 0;
        public void AppendToStdError(string err) => StdError.AppendLine(err);
        public void AppendToStdOutput(string data) => StdOutput.AppendLine(data);
    }
}