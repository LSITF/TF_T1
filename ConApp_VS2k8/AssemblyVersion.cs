using System;
using System.Text;

namespace ConApp_VS2k8
{
    public class AssemblyVersion
    {
        private const string VersionDelimiter = ".";
        
        public static string GetApplicationVersion(bool onlyTwoNumbers)
        {
            //Major.Minor.Build.Revision
            //Version version = new Version("1.0.21596.0");
            Version version = new Version("65534.65534.65534.65534");
            //var version = //Assembly.GetExecutingAssembly().GetName().Version;
            if (version != null)
            {
                var sb = new StringBuilder()
                    .Append(version.Major)
                    .Append(VersionDelimiter)
                    .Append(version.Minor);
                if (!onlyTwoNumbers)
                {
                    sb.Append(VersionDelimiter)
                        .Append(version.Revision)
                        .Append(VersionDelimiter)
                        .Append(version.Build);
                }
                return sb.ToString();
            }
            return string.Empty;
        }
    }
}
