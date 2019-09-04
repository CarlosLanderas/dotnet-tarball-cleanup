using System;
using System.Collections.Generic;
using System.Linq;

namespace dotnet_tarball_cleanup
{
    public class DotnetParser
    {
        public static IEnumerable<(string package, string version)> GetPackages(string stdOutput)
        {
            return (from s in stdOutput.Split(Environment.NewLine).Where(l => l.Length > 0)
                    let parts = s.Split(" ")
                    select new
                    {
                        version = parts[0],
                        location = parts[1].Replace("[", default(string)).Replace("]", default(string))
                    })
                .Select(o => (o.location, o.version))
                .Where(o => o.location != null);
        }
    }
}