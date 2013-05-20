using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using ConApp_VS2k8.Properties;
using ExpertPdf.HtmlToPdf;
using Lsi.Libs.LsiNLogger;

namespace ConApp_VS2k8
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Uri uri = new Uri("http://tfastyn:8080/LrsGuestConnectWs/iQueueSec.asmx?WSDL");
                string a = uri.ToString();
                /*string token = string.Empty;
                if (args != null && args.Length == 1 && args[0] != null && File.Exists(args[0]))
                {
                    Assembly assembly = Assembly.LoadFile(args[0]);
                    token = assembly.GetName().GetPublicKeyToken().ToString();
                    Console.Out.WriteLine(string.Format("Token:[{0}]", token));
                    Console.ReadKey();
                }*/

                //string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                //ConfigurationManager.OpenExeConfiguration()
                //string connStr = (string)Settings.Default["SqlConnStr"];
                //Settings.Default["SqlConnStr"] = "My Setting Value";
                //Settings.Default.Upgrade();

                //Settings.Default.SqlConnStr = "ABC";
                //Settings.Default.Save();
                //Application.LocalUserAppDataPat
                //ApplicationSettings applicationSettings = new ApplicationSettings(this);
                //applicationSettings.Load();

                //CommonAppDataPath 

                /*
                string fullPath = string.Format(@"{0}\{1}", @"d:\!TF\Tests\Application\ConApp_VS2k8\ConApp_VS2k8\files\", string.Format("TransactionReceipt_{0}.pdf", DateTime.Now.ToString("yyyyMMddHHmmssfff")));
                string html = File.ReadAllText(@"d:\!TF\Tests\Application\ConApp_VS2k8\ConApp_VS2k8\files\TransactionMail.html");
                PdfConverter converter = PdfGenerator.GetPdfConverter();
                converter.SavePdfFromHtmlStringToFile(html, fullPath);
                */

                /*
                int b = UInt16.MaxValue - 1;
                string ver = AssemblyVersion.GetApplicationVersion(false);
                string a = ver;
                */
                /*
                const string dir = @"\\DpoLrsSrv\d$\Development\Projects_deploy\PlayPaq_20130312102132\logs\20130314";
                const string file = "SOAP_108_171_181_248_srv2ws.pager.net - Kopia._log_01";
                string path = Path.Combine(dir, file);
                if (args != null && args.Length > 0)
                    path = args[0];
                SoapParser.Srv2SoapParser(path);
                */

            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.ToString());
                LsiLogger.ErrorException("Error occured", ex);
                Console.ReadKey();
            }
        }

       


    }
}
