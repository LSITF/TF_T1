using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using Lsi.Libs.LsiNLogger;
using Lsi.LrsTimeZone.LrsTimeZoneBll;
using PublicDomain;

namespace ConApp_VS2k8
{
    public class OldFuncs
    {
        /*
                //string guid = "123456789";
                //string a = guid.Insert(3, "-").Insert(7, "-");
                //return;
                Dictionary<string, int> dict = new Dictionary<string, int>();
                using (StreamReader sr = new StreamReader(args[0], Encoding.UTF8))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        // <GetCountriesResponse xmlns="lsisoftware.pl">
                        MatchCollection maches = new Regex(@"^<(.+)\s+xmlns=\""lsisoftware.pl\"".*$").Matches(line.Trim());
                        if (maches.Count > 0 && maches[0].Groups.Count > 1)
                        {
                            string ip = maches[0].Groups[1].ToString();
                            if (dict.ContainsKey(ip))
                                dict[ip]++;
                            else
                                dict.Add(ip, 1);
                        }
                    }
                }

                StringBuilder sb = new StringBuilder();
                foreach (KeyValuePair<string, int> keyValuePair in dict)
                    sb.AppendLine(string.Format("IP:{0}\tCount:{1}", keyValuePair.Key, keyValuePair.Value));

                using (StreamWriter sr = File.CreateText(string.Format("{0}_OUT", args[0])))
                {
                    sr.Write(sb);
                    sr.Flush();
                    sr.Close();
                }



                return;*/
                //HTTP_X_FORWARDED_FOR:[41.192.255.122]

                /**/
                
                //PostgreSqlTest(args[0]);
                //return;

                /*string dir = @"d:\Projects\Testy\logs\DataExportTest";
                                long dataAmount = 10;
                                //LsiLogger.Trace(string.Format("Data amount:[{0}]", dataAmount));
                                DataTable dt = ResponsesDAL.GetResponseRawDataTF(dataAmount);
                                if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                                    LsiLogger.Trace(string.Format("Real data amount:[{0}]", dt.Rows.Count));
                
                                int type = 6;
                                switch (type)
                                {
                                    case 1:
                                        //ExcelTest.SaveSmartXLS(false, false, dt, dir);
                                        ExcelTest.CreateSurveyExcelSyncfusion3(ExcelVersion.Excel97to2003, false, dt, dir);
                                        //ExcelTest.CreateSpierXls(Spire.Xls.ExcelVersion.Version97to2003, false, dt, dir);
                                        break;
                                    case 2:
                                        //ExcelTest.SaveSmartXLS(false, true, dt, dir);
                                        ExcelTest.CreateSurveyExcelSyncfusion3(ExcelVersion.Excel97to2003, true, dt, dir);
                                        //ExcelTest.CreateSpierXls(Spire.Xls.ExcelVersion.Version97to2003, true, dt, dir);
                                        break;
                                    case 3:
                                        //ExcelTest.SaveSmartXLS(true, false, dt, dir);
                                        ExcelTest.CreateSurveyExcelSyncfusion3(ExcelVersion.Excel2007, false, dt, dir);
                                        //ExcelTest.CreateSpierXls(Spire.Xls.ExcelVersion.Version2007, false, dt, dir);
                                        break;
                                    case 4:
                                        //ExcelTest.SaveSmartXLS(true, true, dt, dir);
                                        ExcelTest.CreateSurveyExcelSyncfusion3(ExcelVersion.Excel2007, true, dt, dir);
                                        //ExcelTest.CreateSpierXls(Spire.Xls.ExcelVersion.Version2007, true, dt, dir);
                                        break;
                                    case 5:
                                        ExcelTest.CreateSurveyExcelSyncfusion3(ExcelVersion.Excel2010, false, dt, dir);
                                        //ExcelTest.CreateSpierXls(Spire.Xls.ExcelVersion.Version2010, false, dt, dir);
                                        break;
                                    case 6:
                                        ExcelTest.CreateSurveyExcelSyncfusion3(ExcelVersion.Excel2010, true, dt, dir);
                                        //ExcelTest.CreateSpierXls(Spire.Xls.ExcelVersion.Version2010, true, dt, dir);
                                        break;
                                }*/

                //ExcelTest.SaveSmartXLS(false, false, dt, Path.Combine(dir, fileName.Replace(nameKey, "SmartXLS")));
                //ExcelTest.SaveSmartXLS(false, true, dt, Path.Combine(dir, fileName.Replace(nameKey, "SmartXLS_Filter")));
                //ExcelTest.SaveSmartXLS(true, false, dt, Path.Combine(dir, fileName.Replace(nameKey, "SmartXLSX")));
                //ExcelTest.SaveSmartXLS(true, true, dt, Path.Combine(dir, fileName.Replace(nameKey, "SmartXLSX_Filter")));

                //ExcelTest.CreateSurveyExcelSyncfusion(ExcelVersion.Excel97to2003, false, dt, Path.Combine(dir, fileName.Replace(nameKey, "Syncfusion_Excel97to2003")));
                //ExcelTest.CreateSurveyExcelSyncfusion(ExcelVersion.Excel97to2003, true, dt, Path.Combine(dir, fileName.Replace(nameKey, "Syncfusion_Excel97to22003")));
                //ExcelTest.CreateSurveyExcelSyncfusion(ExcelVersion.Excel2007, false, dt, Path.Combine(dir, fileName.Replace(nameKey, "Syncfusion_Excel2007")));
                //ExcelTest.CreateSurveyExcelSyncfusion(ExcelVersion.Excel2007, true, dt, Path.Combine(dir, fileName.Replace(nameKey, "Syncfusion_Excel2007")));
                //ExcelTest.CreateSurveyExcelSyncfusion(ExcelVersion.Excel2010, false, dt, Path.Combine(dir, fileName.Replace(nameKey, "Syncfusion_Excel2010")));
                //ExcelTest.CreateSurveyExcelSyncfusion(ExcelVersion.Excel2010, true, dt, Path.Combine(dir, fileName.Replace(nameKey, "Syncfusion_Excel2010")));
                //return;

                #region Old

                /*string message = "TF:[TEST]";
                UnicodeEncoding unicode = new UnicodeEncoding();
                //UTF8Encoding utf8 = new UTF8Encoding();
                Byte[] encodedBytes = unicode.GetBytes(message);
                message = UnicodeEncoding.Unicode.GetString(encodedBytes);
                string xmlData = "<>\"'&[]!@#$%^&*()";
                string escapedXml = SecurityElement.Escape(xmlData);


                DateTime serverTime = DateTime.Now;
                DateTime myTime = DateTime.Now.AddSeconds(5);

                int sec =  (int) serverTime.Subtract(myTime).TotalMilliseconds;
                myTime = myTime.AddMilliseconds(sec);
                int sec1 = (int)serverTime.Subtract(myTime).TotalMilliseconds;*/


                //dateIn.Subtract(dateOut)

                /* LRSTablerTrackerRequest r = new LRSTablerTrackerRequest();
                 r.Configuration = new LRSTablerTrackerConfigurationDto();
                 r.Configuration.IsSecondWarningTime = 1;
                 r.Orders = new LRSTableTrackerOrderDto[1];
                 r.Orders[0] = new LRSTableTrackerOrderDto();
                 r.Orders[0].StartTime = DateTime.Now;*/
                //new TT.TableTracker().SaveDataAndConfig(r);
                /*string md5 = GetMD5Hash("31337");
                if ("900150983cd24fb0d6963f7d28e17f72" == md5)
                    Console.Out.WriteLine("OK");
                else
                    Console.Out.WriteLine("Error");
                return;*/

                /*string strDt = "2011-11-11 11:11:11";
                //DateTime dt = new DateTime(2011,11,11,11,11,11);
                DateTime dt = DateTime.Parse(strDt);
                long epoch = Epoch(dt);
                return;*/

                /*long locationId = 28;
                int no = 106;


                WLTableDto dto1 = new WLTableDto();
                dto1.WLLocationId = locationId;
                dto1.Number = no.ToString();
                dto1.WLDictServiceDeviceId = 1;

                WLTableDto dto2 = new WLTableDto();
                dto2.WLLocationId = locationId;
                dto2.Number = (no + 1).ToString();
                dto2.WLDictServiceDeviceId = 1;

                new WLTableController().DoubleSave(dto1, dto2);*/

                /*
                string CurrentStartTime = "2011-11-14 09:45:33";
                DateTime startTime;
                if (!string.IsNullOrEmpty(CurrentStartTime) && DateTime.TryParse(CurrentStartTime, out startTime))
                {
                    DateTime dt = startTime;
                    Console.Out.WriteLine(dt.ToString());
                }
                */


                //string srvTime = DateTime.Now.ToUniversalTime().ToString("s");

                /*
                MyTest my = new MyTest();
                my.Date = DateTime.Now;
                my.Id = 1;
                string xml = Serialize(my, true, true, true);

                MyTest my1 = (MyTest) Deserialize(@"d:\!TF\______________Pulpit\MyTest.xml",typeof(MyTest));
                DateTime utc = my1.Date.ToUniversalTime();

                string date = "2011-11-09T15:59:29.451+01:00";
                DateTime dt = DateTime.Parse(date);
                DateTime dtOk = new DateTime(dt.Ticks, DateTimeKind.Local);
                string time = dt.ToString();
                string timeOk = dtOk.ToString();
                 */


                //string response = "0;2011-10-04T16:50:55;120;1";
                //var timeAndGoalData = response.Split('#')[0].Split(';');
                //DateTime? dt = GetDateTimeFromDateString(response);

                //var howManyCar = response.Count(character => character.Equals('#')) - 1;
                //string[] car = response.Split('#');

                //return;
                ////string a = DateTime.Now.ToUniversalTime().ToString("s");
                //return;

                //TestTimeZones();
                //return;

                ///string guid = "CB1231250107404AA38D5CC79D6C6758";
                //ws.Lenovo srv = new Lenovo();
                //ActionReturnOfLocationInfo ret = srv.LocationCheck(guid, "1.0");
                //ActionReturnOfLocationConfig config = srv.GetConfig(guid);

                /*ManagementObjectSearcher s = new ManagementObjectSearcher("SELECT * FROM Win32_Product");
                foreach (ManagementBaseObject baseObject in s.Get())
                {
                    object obj = baseObject;
                }


                return;
                




                //string guid = "0123456789QWERTYUIOPASDFGHJKLZXCVBNM<>{}:<,,./;'[]sdAfsBd-fs!d@f#$%^&*()_+";
                //guid = Regex.Replace(guid, "[^a-zA-Z0-9]", string.Empty);

                //string file = @"d:\SmsHub\_logs\LsiSMSServer.log";
                //ReadLockeedFile(file);

                
                //new Hub().SendMessage("CAS", "+48788278291", "test 2011-06-02 2-UK", "7", true, "MyMessageId");

                //TestTimeZones_KK();

                /*string guid = Guid.NewGuid().ToString();

                //string filePath = @"d:\Projects\REPO_NET\trunk\LsiLogFileListener\LsiLogFileListener\Logs\Test.log";
                string filePath = @"\\jposkrobko2\c$\smshub\_logs\LsiSMSServer.log";

                
                 try
                 {
                     File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.None);
                 }
                 catch (Exception exp)
                 {
                     exp.ToString();

                 }*/


                /*using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
                {

                }*/

                /*foreach (TzTimeZone.TzZoneInfo info in TzTimeZone.ZoneList)
                {
                    Console.Out.WriteLine(info.ZoneName);
                    
                }*/

                //TestTimeZones();


                ////string urlRequest = @"http://smsproxy.pager.net/SmsMailHandler.ashx#%20ERROR:%20In%20Method%20MainLogger;%20after%20time:%2000:00:00.0468750System.Reflection.TargetInvocationExceptio%23%20%23&subject=Error%20in%20TF%20test.log%20-%20ERROR:%20In%20Method%20MainLogger;%20after%20time:%2000:00:00.0468750System.Reflection.TargetInvocationExceptio%23%20ERROR:%20In%20Method%20MainLogger;%20after%20time:%2000:00:00.0468750System.Reflection.TargetInvocationExceptio%23%20%23&mails=tfastyn@lsisoftware.pl";
                //string urlRequest = "http://smsproxy.pager.net/SmsMailHandler.ashx?guid=9feb3f8bd99a407c86c2e2d14cef3ffa&msg=Error in TF test.log - ERROR: In Method MainLogger; after time: 00:00:00.0468750System.Reflection.TargetInvocationExceptio ERROR: In Method MainLogger; after time: 00:00:00.0468750System.Reflection.TargetInvocationExceptio &subject=Error in TF test.log - ERROR: In Method MainLogger; after time: 00:00:00.0468750System.Reflection.TargetInvocationExceptio ERROR: In Method MainLogger; after time: 00:00:00.0468750System.Reflection.TargetInvocationExceptio &mails=tfastyn@lsisoftware.pl";

                //Uri uri = new Uri(urlRequest);

                //WebClient myWebClient = new WebClient();
                //NameValueCollection myNameValueCollection = new NameValueCollection();
                //if (uri.Query.Length > 0)
                //{
                //    foreach (string item in uri.Query.Split('&'))
                //    {
                //        string[] parts = item.Replace("?", string.Empty).Split('=');
                //        if (parts.Length == 2)
                //        {
                //            //LsiLogger.Trace(string.Format("Add(Name:[{0}],Value:[{1}]);", parts[0], parts[1]));
                //            myNameValueCollection.Add(parts[0], parts[1]);
                //        }
                //    }
                //}

                ////string a = Guid.NewGuid().ToString();

                //DateTime lastMody = new DateTime(2011, 05, 03, 21, 15, 59, 120);
                //DateTime creation = new DateTime(2011, 05, 03, 21, 15, 59, 121);

                //double milisek = lastMody.Subtract(creation).TotalMilliseconds;

                //if (lastMody.Subtract(creation).TotalMilliseconds < 0)
                //{
                //    string a = "set Offset =0";
                //}

                ///*string file1 = @"d:\!TF\Logs\2169_Calls\test\OUT\20110415_2169_LRSDB2_Requests.log";
                //string file2 = @"d:\!TF\Logs\2169_Calls\test\OUT\20110415_2169_LRSDB2_Responses.log";
                //string dest = @"d:\!TF\Logs\2169_Calls\test\OUT\20110415_2169_LRSDB2.log";
                //JoinFiles(file1, file2, dest);*/

                #endregion Old

        private static void GetComTransactionconfig(string path)
        {
            path = @"d:\Projects\REPO_LRS\trunk\LrsPlayPaq\PlaypaqWeb\PlayPaqWebBll";

            if (Directory.Exists(path))
            {
                //string fileMask = "LRSCASCallController.cs";
                string fileMask = "*.cs";
                string[] files = Directory.GetFiles(path, fileMask, SearchOption.AllDirectories);
                StringBuilder info = new StringBuilder();
                foreach (string file in files)
                {
                    bool isFileNameAdded = false;
                    if (File.Exists(file))
                    {
                        string[] lines = File.ReadAllLines(file);
                        foreach (string line in lines)
                        {
                            Match match = new Regex(@"^.*(\[Transaction\(.+\)\]).*$").Match(line);
                            if (match != null && match.Groups != null && match.Groups.Count > 1
                                && !string.IsNullOrEmpty(match.Groups[1].Value))
                            {
                                if (!isFileNameAdded)
                                {
                                    info.AppendLine();
                                    info.AppendLine(Path.GetFileName(file));
                                    isFileNameAdded = true;
                                }
                                info.AppendLine(match.Groups[1].Value);
                            }
                        }
                    }
                    if (isFileNameAdded)
                        info.AppendLine();
                }
                LsiLogger.Trace(info.ToString());
            }
        }

        private static void PostgreSqlTest(string connectionString)
        {
            PostgreDataController pgdc = new PostgreDataController(connectionString);
            int? clientUid = null;
            int? locationUid = null;

            try
            {
                clientUid = pgdc.StartInsertClient("LSI TF corp 3");
                if (!clientUid.HasValue)
                    throw new Exception("No clientUid");
                pgdc.CommitTransaction();
            }
            catch (Exception ex)
            {
                LsiLogger.ErrorException("Error in StartInsertClient()", ex);
                pgdc.RollbackTransaction();
            }

            try
            {
                locationUid = pgdc.StartInsertLocation((int)clientUid, 1, "LSI TF comp 3");
                if (!locationUid.HasValue)
                    throw new Exception("No locationUid");
                pgdc.CommitTransaction();
            }
            catch (Exception ex)
            {
                LsiLogger.ErrorException("Error in StartInsertLocation()", ex);
                pgdc.RollbackTransaction();
            }

            try
            {
                pgdc.StartInsertBases(2407, (int)locationUid);
                pgdc.CommitTransaction();
            }
            catch (Exception ex)
            {
                LsiLogger.ErrorException("Error in StartInsertBases()", ex);
                pgdc.RollbackTransaction();
            }

        }

        public static string GetMD5Hash(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("X2"));
            return sb.ToString();
        }

        public static long Epoch(DateTime date)
        {
            return (date.Ticks - 621355968000000000) / 10000000;
        }

        public static object Deserialize(string path, Type type)
        {
            TextReader rd = null;
            object obj;
            try
            {
                XmlSerializer serial = new XmlSerializer(type);
                rd = new StreamReader(path, new UTF8Encoding());
                obj = serial.Deserialize(rd);
            }
            finally
            {
                if (rd != null)
                {
                    rd.Close();
                }
            }
            return obj;
        }

        public static string Serialize(object o, bool withOutXmlDeclaration, bool withOutNamespaces, bool isTagInNewLine)
        {
            XmlWriterSettings XmlSettings = new XmlWriterSettings();
            XmlSettings.Encoding = new UTF8Encoding();
            XmlSettings.OmitXmlDeclaration = withOutXmlDeclaration;
            XmlSettings.Indent = isTagInNewLine;
            XmlSerializer s = new XmlSerializer(o.GetType());
            MemoryStream ms = new MemoryStream();
            XmlWriter wr = XmlWriter.Create(ms, XmlSettings);
            if (withOutNamespaces)
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                s.Serialize(wr, o, ns);
            }
            else
            {
                s.Serialize(wr, o);
            }
            string xmlString = Encoding.UTF8.GetString(ms.ToArray());
            wr.Close();
            ms.Close();
            return xmlString;
        }




        private static void ReadLockeedFile(string fileFullPath)
        {
            if (File.Exists(fileFullPath))
            {
                FileStream logFileStream = new FileStream(fileFullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader logFileReader = new StreamReader(logFileStream);

                while (!logFileReader.EndOfStream)
                {
                    string line = logFileReader.ReadLine();
                    // Your code here
                }

                // Clean up
                logFileReader.Close();
                logFileStream.Close();
            }
        }

        private static void TestTimeZones()
        {
            string[] timeZones = new[] {
               "Africa/Abidjan",
"Africa/Accra",
"Africa/Addis_Ababa",
"Africa/Algiers",
"Africa/Asmara",
"Africa/Asmera",
"Africa/Bamako",
"Africa/Bangui",
"Africa/Banjul",
"Africa/Bissau",
"Africa/Blantyre",
"Africa/Brazzaville",
"Africa/Bujumbura",
"Africa/Cairo",
"Africa/Casablanca",
"Africa/Ceuta",
"Africa/Conakry",
"Africa/Dakar",
"Africa/Dar_es_Salaam",
"Africa/Djibouti",
"Africa/Douala",
"Africa/El_Aaiun",
"Africa/Freetown",
"Africa/Gaborone",
"Africa/Harare",
"Africa/Johannesburg",
"Africa/Kampala",
"Africa/Khartoum",
"Africa/Kigali",
"Africa/Kinshasa",
"Africa/Lagos",
"Africa/Libreville",
"Africa/Lome",
"Africa/Luanda",
"Africa/Lubumbashi",
"Africa/Lusaka",
"Africa/Malabo",
"Africa/Maputo",
"Africa/Maseru",
"Africa/Mbabane",
"Africa/Mogadishu",
"Africa/Monrovia",
"Africa/Nairobi",
"Africa/Ndjamena",
"Africa/Niamey",
"Africa/Nouakchott",
"Africa/Ouagadougou",
"Africa/Porto-Novo",
"Africa/Sao_Tome",
"Africa/Timbuktu",
"Africa/Tripoli",
"Africa/Tunis",
"Africa/Windhoek",
"US/Alaska",
"US/Aleutian",
"America/Adak",
"America/Anchorage",
"America/Anguilla",
"America/Antigua",
"America/Araguaina",
"America/Argentina/Buenos_Aires",
"America/Argentina/Catamarca",
"America/Argentina/ComodRivadavia",
"America/Argentina/Cordoba",
"America/Argentina/Jujuy",
"America/Argentina/La_Rioja",
"America/Argentina/Mendoza",
"America/Argentina/Rio_Gallegos",
"America/Argentina/San_Juan",
"America/Argentina/San_Luis",
"America/Argentina/Tucuman",
"America/Argentina/Ushuaia",
"America/Aruba",
"America/Asuncion",
"America/Atikokan",
"America/Atka",
"America/Bahia",
"America/Barbados",
"America/Belem",
"America/Belize",
"America/Blanc-Sablon",
"America/Boa_Vista",
"America/Bogota",
"America/Boise",
"America/Buenos_Aires",
"America/Cambridge_Bay",
"America/Campo_Grande",
"America/Cancun",
"America/Caracas",
"America/Catamarca",
"America/Cayenne",
"America/Cayman",
"America/Chicago",
"America/Chihuahua",
"America/Coral_Harbour",
"America/Cordoba",
"America/Costa_Rica",
"America/Cuiaba",
"America/Curacao",
"America/Danmarkshavn",
"America/Dawson",
"America/Dawson_Creek",
"America/Denver",
"America/Detroit",
"America/Dominica",
"America/Edmonton",
"America/Eirunepe",
"America/El_Salvador",
"America/Ensenada",
"America/Fort_Wayne",
"America/Fortaleza",
"America/Glace_Bay",
"America/Godthab",
"America/Goose_Bay",
"America/Grand_Turk",
"America/Grenada",
"America/Guadeloupe",
"America/Guatemala",
"America/Guayaquil",
"America/Guyana",
"America/Halifax",
"America/Havana",
"America/Hermosillo",
"America/Indiana/Indianapolis",
"America/Indiana/Knox",
"America/Indiana/Marengo",
"America/Indiana/Petersburg",
"America/Indiana/Tell_City",
"America/Indiana/Vevay",
"America/Indiana/Vincennes",
"America/Indiana/Winamac",
"America/Indianapolis",
"America/Inuvik",
"America/Iqaluit",
"America/Jamaica",
"America/Jujuy",
"America/Juneau",
"America/Kentucky/Louisville",
"America/Kentucky/Monticello",
"America/Knox_IN",
"America/La_Paz",
"America/Lima",
"America/Los_Angeles",
"America/Louisville",
"America/Maceio",
"America/Managua",
"America/Manaus",
"America/Marigot",
"America/Martinique",
"America/Mazatlan",
"America/Mendoza",
"America/Menominee",
"America/Merida",
"America/Mexico_City",
"America/Miquelon",
"America/Moncton",
"America/Monterrey",
"America/Montevideo",
"America/Montreal",
"America/Montserrat",
"America/Nassau",
"America/New_York",
"America/Nipigon",
"America/Nome",
"America/Noronha",
"America/North_Dakota/Center",
"America/North_Dakota/New_Salem",
"America/Panama",
"America/Pangnirtung",
"America/Paramaribo",
"America/Phoenix",
"America/Port_of_Spain",
"America/Port-au-Prince",
"America/Porto_Acre",
"America/Porto_Velho",
"America/Puerto_Rico",
"America/Rainy_River",
"America/Rankin_Inlet",
"America/Recife",
"America/Regina",
"America/Resolute",
"America/Rio_Branco",
"America/Rosario",
"America/Santarem",
"America/Santiago",
"America/Santo_Domingo",
"America/Sao_Paulo",
"America/Scoresbysund",
"America/Shiprock",
"America/St_Barthelemy",
"America/St_Johns",
"America/St_Kitts",
"America/St_Lucia",
"America/St_Thomas",
"America/St_Vincent",
"America/Swift_Current",
"America/Tegucigalpa",
"America/Thule",
"America/Thunder_Bay",
"America/Tijuana",
"America/Toronto",
"America/Tortola",
"America/Vancouver",
"America/Virgin",
"America/Whitehorse",
"America/Winnipeg",
"America/Yakutat",
"America/Yellowknife",
"Antarctica/Casey",
"Antarctica/Davis",
"Antarctica/DumontDUrville",
"Antarctica/Mawson",
"Antarctica/McMurdo",
"Antarctica/Palmer",
"Antarctica/Rothera",
"Antarctica/South_Pole",
"Antarctica/Syowa",
"Antarctica/Vostok",
"Arctic/Longyearbyen",
"US/Arizona",
"Asia/Aden",
"Asia/Almaty",
"Asia/Amman",
"Asia/Anadyr",
"Asia/Aqtau",
"Asia/Aqtobe",
"Asia/Ashgabat",
"Asia/Ashkhabad",
"Asia/Baghdad",
"Asia/Bahrain",
"Asia/Baku",
"Asia/Bangkok",
"Asia/Beirut",
"Asia/Bishkek",
"Asia/Brunei",
"Asia/Calcutta",
"Asia/Choibalsan",
"Asia/Chongqing",
"Asia/Chungking",
"Asia/Colombo",
"Asia/Dacca",
"Asia/Damascus",
"Asia/Dhaka",
"Asia/Dili",
"Asia/Dubai",
"Asia/Dushanbe",
"Asia/Gaza",
"Asia/Harbin",
"Asia/Ho_Chi_Minh",
"Asia/Hong_Kong",
"Asia/Hovd",
"Asia/Irkutsk",
"Asia/Istanbul",
"Asia/Jakarta",
"Asia/Jayapura",
"Asia/Jerusalem",
"Asia/Kabul",
"Asia/Kamchatka",
"Asia/Karachi",
"Asia/Kashgar",
"Asia/Katmandu",
"Asia/Kolkata",
"Asia/Krasnoyarsk",
"Asia/Kuala_Lumpur",
"Asia/Kuching",
"Asia/Kuwait",
"Asia/Macao",
"Asia/Macau",
"Asia/Magadan",
"Asia/Makassar",
"Asia/Manila",
"Asia/Muscat",
"Asia/Nicosia",
"Asia/Novosibirsk",
"Asia/Omsk",
"Asia/Oral",
"Asia/Phnom_Penh",
"Asia/Pontianak",
"Asia/Pyongyang",
"Asia/Qatar",
"Asia/Qyzylorda",
"Asia/Rangoon",
"Asia/Riyadh",
"Asia/Riyadh87",
"Asia/Riyadh88",
"Asia/Riyadh89",
"Asia/Saigon",
"Asia/Sakhalin",
"Asia/Samarkand",
"Asia/Seoul",
"Asia/Shanghai",
"Asia/Singapore",
"Asia/Taipei",
"Asia/Tashkent",
"Asia/Tbilisi",
"Asia/Tehran",
"Asia/Tel_Aviv",
"Asia/Thimbu",
"Asia/Thimphu",
"Asia/Tokyo",
"Asia/Ujung_Pandang",
"Asia/Ulaanbaatar",
"Asia/Ulan_Bator",
"Asia/Urumqi",
"Asia/Vientiane",
"Asia/Vladivostok",
"Asia/Yakutsk",
"Asia/Yekaterinburg",
"Asia/Yerevan",
"Atlantic/Azores",
"Atlantic/Bermuda",
"Atlantic/Canary",
"Atlantic/Cape_Verde",
"Atlantic/Faeroe",
"Atlantic/Faroe",
"Atlantic/Jan_Mayen",
"Atlantic/Madeira",
"Atlantic/Reykjavik",
"Atlantic/South_Georgia",
"Atlantic/St_Helena",
"Atlantic/Stanley",
"Australia/ACT",
"Australia/Adelaide",
"Australia/Brisbane",
"Australia/Broken_Hill",
"Australia/Canberra",
"Australia/Currie",
"Australia/Darwin",
"Australia/Eucla",
"Australia/Hobart",
"Australia/LHI",
"Australia/Lindeman",
"Australia/Lord_Howe",
"Australia/Melbourne",
"Australia/North",
"Australia/NSW",
"Australia/Perth",
"Australia/Queensland",
"Australia/South",
"Australia/Sydney",
"Australia/Tasmania",
"Australia/Victoria",
"Australia/West",
"Australia/Yancowinna",
"Brazil/Acre",
"Brazil/DeNoronha",
"Brazil/East",
"Brazil/West",
"Canada/Atlantic",
"Canada/Central",
"Canada/Eastern",
"Canada/East-Saskatchewan",
"Canada/Mountain",
"Canada/Newfoundland",
"Canada/Pacific",
"Canada/Saskatchewan",
"Canada/Yukon",
"US/Central",
"CET",
"Chile/Continental",
"Chile/EasterIsland",
"CST6CDT",
"Cuba",
"US/Eastern",
"US/East-Indiana",
"EET",
"Egypt",
"Eire",
"EST",
"EST5EDT",
"Etc/GMT",
"Etc/GMT+0",
"Etc/GMT+1",
"Etc/GMT+10",
"Etc/GMT+11",
"Etc/GMT+12",
"Etc/GMT+2",
"Etc/GMT+3",
"Etc/GMT+4",
"Etc/GMT+5",
"Etc/GMT+6",
"Etc/GMT+7",
"Etc/GMT+8",
"Etc/GMT+9",
"Etc/GMT0",
"Etc/GMT-0",
"Etc/GMT-1",
"Etc/GMT-10",
"Etc/GMT-11",
"Etc/GMT-12",
"Etc/GMT-13",
"Etc/GMT-16",
"Etc/GMT-2",
"Etc/GMT-3",
"Etc/GMT-4",
"Etc/GMT-5",
"Etc/GMT-6",
"Etc/GMT-7",
"Etc/GMT-8",
"Etc/GMT-9",
"Etc/Greenwich",
"Etc/UCT",
"Etc/Universal",
"Etc/UTC",
"Etc/Zulu",
"Europe/Amsterdam",
"Europe/Andorra",
"Europe/Athens",
"Europe/Belfast",
"Europe/Belgrade",
"Europe/Berlin",
"Europe/Bratislava",
"Europe/Brussels",
"Europe/Bucharest",
"Europe/Budapest",
"Europe/Chisinau",
"Europe/Copenhagen",
"Europe/Dublin",
"Europe/Gibraltar",
"Europe/Guernsey",
"Europe/Helsinki",
"Europe/Isle_of_Man",
"Europe/Istanbul",
"Europe/Jersey",
"Europe/Kaliningrad",
"Europe/Kiev",
"Europe/Lisbon",
"Europe/Ljubljana",
"Europe/London",
"Europe/Luxembourg",
"Europe/Madrid",
"Europe/Malta",
"Europe/Mariehamn",
"Europe/Minsk",
"Europe/Monaco",
"Europe/Moscow",
"Europe/Nicosia",
"Europe/Oslo",
"Europe/Paris",
"Europe/Podgorica",
"Europe/Prague",
"Europe/Riga",
"Europe/Rome",
"Europe/Samara",
"Europe/San_Marino",
"Europe/Sarajevo",
"Europe/Simferopol",
"Europe/Skopje",
"Europe/Sofia",
"Europe/Stockholm",
"Europe/Tallinn",
"Europe/Tirane",
"Europe/Tiraspol",
"Europe/Uzhgorod",
"Europe/Vaduz",
"Europe/Vatican",
"Europe/Vienna",
"Europe/Vilnius",
"Europe/Volgograd",
"Europe/Warsaw",
"Europe/Zagreb",
"Europe/Zaporozhye",
"Europe/Zurich",
"GB",
"GB-Eire",
"GMT",
"GMT+0",
"GMT0",
"GMT-0",
"Greenwich",
"US/Hawaii",
"Hongkong",
"HST",
"Iceland",
"Indian/Antananarivo",
"Indian/Chagos",
"Indian/Christmas",
"Indian/Cocos",
"Indian/Comoro",
"Indian/Kerguelen",
"Indian/Mahe",
"Indian/Maldives",
"Indian/Mauritius",
"Indian/Mayotte",
"Indian/Reunion",
"Iran",
"Israel",
"Jamaica",
"Japan",
"Kwajalein",
"Libya",
"MET",
"Mexico/BajaNorte",
"Mexico/BajaSur",
"Mexico/General",
"US/Michigan",
"Mideast/Riyadh87",
"Mideast/Riyadh88",
"Mideast/Riyadh89",
"US/Mountain",
"MST",
"MST7MDT",
"Navajo",
"NZ",
"NZ-CHAT",
"US/Pacific-New",
"US/Pacific",
"Pacific/Apia",
"Pacific/Auckland",
"Pacific/Chatham",
"Pacific/Easter",
"Pacific/Efate",
"Pacific/Enderbury",
"Pacific/Fakaofo",
"Pacific/Fiji",
"Pacific/Funafuti",
"Pacific/Galapagos",
"Pacific/Gambier",
"Pacific/Guadalcanal",
"Pacific/Guam",
"Pacific/Honolulu",
"Pacific/Johnston",
"Pacific/Kiritimati",
"Pacific/Kosrae",
"Pacific/Kwajalein",
"Pacific/Majuro",
"Pacific/Marquesas",
"Pacific/Midway",
"Pacific/Nauru",
"Pacific/Niue",
"Pacific/Norfolk",
"Pacific/Noumea",
"Pacific/Pago_Pago",
"Pacific/Palau",
"Pacific/Pitcairn",
"Pacific/Ponape",
"Pacific/Port_Moresby",
"Pacific/Rarotonga",
"Pacific/Saipan",
"Pacific/Samoa",
"Pacific/Tahiti",
"Pacific/Tarawa",
"Pacific/Tongatapu",
"Pacific/Truk",
"Pacific/Wake",
"Pacific/Wallis",
"Pacific/Yap",
"Poland",
"Portugal",
"PRC",
"PST8PDT",
"ROC",
"ROK",
"US/Samoa",
"Singapore",
"Turkey",
"UCT",
"Universal",
"US/Indiana-Starke",
"UTC",
"WET",
"W-SU",
"Zulu"
                };
            foreach (string timeZone in timeZones)
            {
                try
                {
                    DateTime utc = DateTime.UtcNow;
                    DateTime? ret = LrsTimeZoneBll.GetTimeForTimeZoneFromUtcTime(timeZone, utc);
                    if (ret == null)
                        Console.Out.WriteLine("Small error while timeZone:" + timeZone);
                    else
                    {
                        Console.Out.WriteLine(string.Format("{0}\t{1}",
                            timeZone, ((DateTime)ret).Subtract(utc).TotalMinutes));
                    }
                }
                catch (Exception)
                {
                    Console.Out.WriteLine("Error while timeZone:" + timeZone);
                }
            }
        }

        private static void TestTimeZones_KK()
        {
            //tylko tomku powiedz mi czemu np. 
            //america/detroit jest ok, ammerica/mexico city jest ok,
            //a cent. standart time jest nie ok

            DateTime now = DateTime.UtcNow;
            Console.Out.WriteLine("UTC:[{0}]", now);

            string[] timeZones = new[] { "Poland", "US/Central", "America/Detroit", "America/Mexico_City" };
            foreach (string timeZone in timeZones)
            {
                try
                {
                    DateTime? ret = LrsTimeZoneBll.GetTimeForTimeZoneFromUtcTime(timeZone, now);
                    if (ret == null)
                        Console.Out.WriteLine("Error while timeZone:" + timeZone);
                    Console.Out.WriteLine("TimeZone:[{0}], Time:[{1}]", timeZone, ret);
                }
                catch (Exception)
                {
                    Console.Out.WriteLine("Error while timeZone:" + timeZone);
                }
            }
            Console.In.ReadLine();
        }

        /*public static int GetTimeZoneOffSet(string timeZoneId)
        {
            var utc = DateTime.UtcNow;
            return Int32.Parse(GetTimeFromLocationTimeZone(timeZoneId, utc).Subtract(utc).TotalMinutes.ToString());
        }

        public static DateTime GetTimeFromLocationTimeZone(string timeZoneId, DateTime currentTime)
        {
            var timeZoneName = GetTimeZoneNameForLocation(locationId);
            return !string.IsNullOrEmpty(timeZoneName) ? GetTimeForTimeZoneFromUtcTime(timeZoneName, currentTime) : currentTime;
        }*/

        public static DateTime GetTimeForTimeZoneFromUtcTime(string timeZoneName, DateTime utcTime)
        {
            if (string.IsNullOrEmpty(timeZoneName))
            {
                return utcTime;
            }

            var time = new DateTime(utcTime.Ticks, DateTimeKind.Utc);
            var zone = TzTimeZone.GetTimeZone(timeZoneName);
            if (zone != null)
            {
                var local = new TzDateTime(time, zone);
                if (local.TimeZone != null)
                {
                    return local.DateTimeLocal;
                }
            }

            return utcTime;
        }

        public static DateTime? GetDateTimeFromDateString(string data)
        {
            DateTime? ret = null;
            if (!string.IsNullOrEmpty(data))
            {
                string[] values = data.Split('#');
                if (values.Length > 0)
                {
                    string[] items = values[0].Split(';');
                    DateTime dt;
                    if (items.Length > 0 && items[1] != null && DateTime.TryParse(items[1], out dt))
                        ret = dt;
                }
            }
            return ret;
        }

        #region Files joiner
        /*private static void JoinFiles(string file1, string file2, string destFile)
        {
            StringBuilder body1 = Famar.Utils.FileUtils.ReadFile(file1);
            string[] lines1 = Regex.Split(body1.ToString(), "\\r\\n\\r\\n");
            Dictionary<long, string> dict1 = CreateDictFromLine(lines1);

            StringBuilder body2 = Famar.Utils.FileUtils.ReadFile(file2);
            string[] lines2 = Regex.Split(body2.ToString(), "\\r\\n\\r\\n");
            Dictionary<long, string> dict2 = CreateDictFromLine(lines2);

            SortedDictionary<long, string> dict = SortDict(JoinDicts(dict1, dict2));
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<long, string> pair in dict)
            {
                sb.AppendLine(pair.Value);
                sb.AppendLine(string.Empty);
            }

            Famar.Utils.FileUtils.CreateFileWithMove(destFile, sb.ToString());
        }*/

        private static Dictionary<long, string> JoinDicts(Dictionary<long, string> d1, Dictionary<long, string> d2)
        {
            Dictionary<long, string> ret = new Dictionary<long, string>();
            foreach (KeyValuePair<long, string> keyValuePair in d1)
                ret.Add(keyValuePair.Key, keyValuePair.Value);

            foreach (KeyValuePair<long, string> keyValuePair in d2)
                ret.Add(keyValuePair.Key, keyValuePair.Value);
            return ret;
        }


        private static Dictionary<long, string> CreateDictFromLine(string[] lines1)
        {
            Dictionary<long, string> lines = new Dictionary<long, string>();
            int counter = 1;
            foreach (var l1 in lines1)
            {
                bool added = false;
                MatchCollection matches = new Regex(@"\[(\d{4}-\d{2}-\d{2}\s{1}\d{2}\:\d{2}\:\d{2}\.\d{4})\]Message\:", RegexOptions.Multiline).Matches(l1);
                if (matches.Count > 0)
                {
                    if (matches[0].Groups.Count > 1)
                    {
                        string a = matches[0].Groups[1].Value;

                        DateTime dt;
                        if (DateTime.TryParse(a, out dt))
                        {
                            lines.Add(dt.Ticks, l1);
                            added = true;
                        }
                    }
                }
                if (!added)
                    System.Console.Out.WriteLine("Line:[{0}] not added", counter);
                counter++;
            }
            return lines;
        }

        private static SortedDictionary<long, string> SortDict(Dictionary<long, string> dict)
        {
            SortedDictionary<long, string> sortedSections = null;
            if (dict != null)
                sortedSections = new SortedDictionary<long, string>(dict);
            return sortedSections;
        }
        #endregion Files joiner

    }

    [Serializable]
    public class MyTest
    {
        private DateTime _date;
        private long _id;

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
