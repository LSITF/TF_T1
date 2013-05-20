using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Lsi.Libs.LsiNLogger;
using Lsi.LrsSrv2Bll;

namespace ConApp_VS2k8
{
    class OldCode
    {
        static void MainOld(string[] args)
        {
            try
            {
                //iQueueTest.SaveSectionBackground();
                //iQueueTest.GetSectionBackground();

                /* int A_1 = 15;
                 string a1 = b("ꇱ믳냵곷극뷻곽䗿", A_1);
                 string a2 = b("뿱鷳闵諷闹迻釽替瘁", A_1);
                 string a3 = b("믱髳苵鷷裹鋻鯽瓿∁䄃縅砇昉挋簍甏怑", A_1);
                 string a4 = b("뿱뗳뿵뛷", A_1);
                 string a5 = b("등釳韵賷迹軻鯽䏿洁樃爅稇攉怋", A_1);
                 string a6 = b("등뇳럵곷꿹껻믽忿䬁刃伅䴇崉䌋䰍娏圑圓䈕尗䠙崛䤝缟昡椣樥簧ጩ猫礭礯昱簳椵缷縹画", A_1);
                 string a7 = b("\xD8F1", A_1);


                 string all = string.Format(@"{0}\{1}\{2}\{3}\{4}\{5}\{6}", a1, a2, a3, a4, a5, a6, a7);
                 //"FEATURE_IVIEWOBJECTDRAW_DMLT9_WITH_GDI"
                 */

                //new Thread(TTSaveDataAndConfig_1).Start();
                //new Thread(TTSaveDataAndConfig_2).Start();
                return;

                //CreateRequest

                /*int min = int.MinValue;
                int max = int.MaxValue;
                int a = 2147483647;
                checked
                {
                    int b = a + 1;
                }*/

                return;
                //Srv2VTISync.DoVTISync(5);
                //return;
                /*SurveyStructureDef srvDef = new SurveyStructureDef();
                srvDef.SurveyId = 1;
                srvDef.CorporaiotnId = 10;
                srvDef.Name = "TF test survey struct";
                
                Prompt[] prompts = new Prompt[2];
                prompts[0] = new Prompt{ Order = 1, PromptId = 1, Text = "P1", ValidationTableId = 3};
                prompts[1] = new Prompt{ Order = 2, PromptId = 2, Text = "P2", ValidationTableId = 4};
                srvDef.Prompts = prompts;


                Question[] questions = new Question[3];
                questions[0] = new Question { AnswerTypeId = 1, IsRequired = false, Order = 1, QuestionId = 1, QuestionTypeId = 1,  Text = "Q1" };
                questions[1] = new Question { AnswerTypeId = 1, IsRequired = false, Order = 2, QuestionId = 2, QuestionTypeId = 2,  Text = "Q2" };
               
                Answer[] answers = new Answer[3];
                answers[0] = new Answer {AnswerId = 1, Content = "A1", Order = 1};
                answers[1] = new Answer {AnswerId = 2, Content = "A2", Order = 2};
                answers[2] = new Answer {AnswerId = 3, Content = "A3", Order = 3};
                questions[2] = new Question { AnswerTypeId = 1, IsRequired = false, Order = 3, QuestionId = 3, QuestionTypeId = 3,  Text = "Q3", Answers = answers};

                srvDef.Questions = questions;

                new Srv2.Srv2().SaveSurveyStructure(srvDef);
                return;*/

                long? corporationSrv2Id = null;
                long? companySrv2Id = null;
                long? srv2ValidationTableId = null;
                long? lrsValidationTableId = null;
                //corporationSrv2Id = 11;
                //companySrv2Id = 23;
                //srv2ValidationTableId = 10;

                //Srv2Bll.SrvValidatioTableItems items = new Srv2Bll.SrvValidatioTableItems();

                //if (companySrv2Id.HasValue)
                //{
                //    items.Add(new Srv2Bll.SrvValidatioTableItem { Id = 0, LrsValidationItemId = 1,
                //        Name = "Pin 1", Value = "1", Srv2CompanyId = companySrv2Id.Value});
                //    items.Add(new Srv2Bll.SrvValidatioTableItem {Id = 0, LrsValidationItemId = 2,
                //        Name = "Pin 2", Value = "2", Srv2CompanyId = companySrv2Id.Value }); 
                //    items.Add(new Srv2Bll.SrvValidatioTableItem {Id = 0, LrsValidationItemId = 3,
                //        Name = "Pin 3", Value = "3", Srv2CompanyId = companySrv2Id.Value});
                //    items.Add(new Srv2Bll.SrvValidatioTableItem {Id = 0, LrsValidationItemId = 4,
                //        Name = "Pin 4", Value = "4", Srv2CompanyId = companySrv2Id.Value});
                //}

                int[] itemsToDelete = null;
                //itemsToDelete = new int[] { 21, 22, 23 };

                //lrsValidationTableId = 2496;

                if (!corporationSrv2Id.HasValue)
                    Srv2SaveCorporation(ref corporationSrv2Id);

                //if (corporationSrv2Id.HasValue && !companySrv2Id.HasValue)
                //Srv2SaveCompany(corporationSrv2Id, ref companySrv2Id);

                //if (corporationSrv2Id.HasValue && !srv2ValidationTableId.HasValue) SaveValidationTable(corporationSrv2Id.Value, lrsValidationTableId, ref srv2ValidationTableId);

                //Delete ValidationTable
                //if (srv2ValidationTableId.HasValue) DeleteValidationTable(srv2ValidationTableId.Value);

                //if (srv2ValidationTableId.HasValue && items.Count > 0) SaveValidationTableItem(srv2ValidationTableId.Value, items);

                //Delete ValidationTableItems if  (itemsToDelete != null && itemsToDelete.Length > 0) DeleteValidationTableIetms(itemsToDelete);
                Console.Out.WriteLine("Koniec");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.ToString());
                LsiLogger.ErrorException("Error occured", ex);
                Console.ReadKey();
            }
        }

        #region SRV2
        private static bool Srv2SaveCompany(long? corporationSrv2Id, ref long? companySrv2Id)
        {
            bool returnValue = false;
            if (corporationSrv2Id.HasValue)
            {
                string name = GetDateString("LSI TF Company SRV2");
                string timeZone = "US/Eastern";
                string clientUrl = "http://example.com";
                string clientUrlText = "My web";
                string country = "United States";
                string state = "Texas";
                string city = "Test City";
                string zipCode = "13579";
                string adrs1 = "f";
                string adrs2 = string.Empty;
                long srv2CorporationId = corporationSrv2Id.Value;

                string logoName = string.Empty;
                byte[] logo = null;

                returnValue = Srv2Bll.SaveCompany(name, timeZone, clientUrl, clientUrlText, logo, logoName,
                                                  country, state, city, zipCode, adrs1, adrs2, srv2CorporationId,
                                                  ref companySrv2Id);
            }
            return returnValue;
        }

        private static bool Srv2SaveCorporation(ref long? corporationSrv2Id)
        {
            bool returnValue;
            string name = GetDateString("LSI TF Corporation SRV2");
            returnValue = Srv2Bll.SaveCorporation(name, ref corporationSrv2Id);
            return returnValue;
        }

        /*private static bool SaveValidationTable(long srv2CorporationId, long? lrsValidationTableId, ref long? srv2ValidationTableId)
        {
            bool returnValue;
            string name = GetDateString("LSI TF ValidationTable SRV2");
            returnValue = Srv2Bll.SaveValidationTable(name, srv2CorporationId, lrsValidationTableId, ref srv2ValidationTableId);
            return returnValue;
        }

        private static bool DeleteValidationTable(long srv2ValidationTableId)
        {
            bool returnValue;
            returnValue = Srv2Bll.DeleteValidationTable(srv2ValidationTableId);
            return returnValue;
        }*/

        /*private static bool SaveValidationTableItem(long srv2ValidationTableId, Srv2Bll.SrvValidatioTableItems items)
        {
            bool returnValue;
            returnValue = Srv2Bll.SaveValidationTableItem(srv2ValidationTableId, items);
            return returnValue;
        }

        private static bool DeleteValidationTableIetms(int[] items)
        {
            bool returnValue;
            returnValue = Srv2Bll.DeleteValidationTableItem(items);
            return returnValue;
        }*/

        #endregion SRV2

        #region Tools

        public static string ConvertStringToHex(String input)
        {
            Byte[] stringBytes = Encoding.ASCII.GetBytes(input);
            StringBuilder sbBytes = new StringBuilder(stringBytes.Length * 2);
            foreach (byte b in stringBytes)
            {
                sbBytes.AppendFormat("{0:X2}", b);
            }
            return sbBytes.ToString();
        }

        public static string ConvertHexToString(String hexInput)
        {
            int numberChars = hexInput.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexInput.Substring(i, 2), 16);
            }
            return Encoding.ASCII.GetString(bytes);
        }

        public static string GetEnumDescription(Enum value)
        {
            /*PageItemRecord.FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes != null && attributes.Length > 0 ? attributes[0].Description : value.ToString();*/
            return null;
        }

        private static void SaveGuestCounter(string file)
        {
            List<string> guids = new List<string>();
            guids.Add("E68670F47C244DE1B49F236BDC9BB3A0");
            guids.Add("BC5B9F9367C6476D930F46B560BFE16C");
            guids.Add("10146650F2B943688D49CA8D6A8E47F7");
            guids.Add("7C918DE0C4C143048D6BF962FA3175E1");
            guids.Add("FB1560645B914387B1FB08A3867AAF83");
            guids.Add("DD20E416A1774B16B06E56A4261B6891");
            guids.Add("C923B4D7D41D489B883F79F906CFABA7");
            guids.Add("301C2F3E6FB142B98F52E571DFB0573F");
            guids.Add("2C1CFC8022DF41D08E061525CB91673F");
            guids.Add("64F13369D1D74793ABD38C75430B79A1");
            guids.Add("96F93145238A4BAB8B2587736A67893E");
            guids.Add("32F321DD24574A7E8E07CB5CC542B615");
            guids.Add("531FB1AE84F447FD96142EA0719140D6");
            guids.Sort();

            Dictionary<string, long> cache = new Dictionary<string, long>();

            if (File.Exists(file))
            {
                string fileBody = File.ReadAllText(file);
                string[] lines = Regex.Split(fileBody, "Client IP address");
                if (lines != null && lines.Length > 0)
                {
                    foreach (string line in lines)
                    {
                        string newLine = line;
                        newLine = newLine.Replace("\t", string.Empty);
                        newLine = newLine.Replace("\r", string.Empty);
                        newLine = newLine.Replace("\n", string.Empty);

                        string pattern = @".*SaveGuest.*restaurantGuid>(.+)</restaurantGuid>.*";
                        Regex reg = new Regex(pattern, RegexOptions.Multiline);
                        MatchCollection matches = reg.Matches(newLine);
                        if (matches.Count > 0)
                        {
                            if (matches[0].Groups.Count > 1)
                            {
                                string restGuid = matches[0].Groups[1].Value;
                                if (!cache.ContainsKey(restGuid.ToUpper()))
                                    cache.Add(restGuid.ToUpper(), 0);

                                Regex reGuest = new Regex(@"(GuestInfo\s)", RegexOptions.Multiline);
                                MatchCollection matchesGuest = reGuest.Matches(newLine);
                                if (matchesGuest.Count > 0)
                                {
                                    cache[restGuid.ToUpper()] += matchesGuest.Count;
                                    //Console.WriteLine(string.Format("{0}\t{1}", restGuid, matchesGuest.Count));
                                }
                            }
                        }
                    }
                }

                if (cache.Count > 0)
                {
                    foreach (KeyValuePair<string, long> keyVale in cache)
                    {
                        Console.WriteLine(string.Format("{0}\t{1}", keyVale.Key, keyVale.Value));
                    }
                }
            }
        }

        private static void WaitListUpdatesCounter(string file)
        {
            /*List<string> guids = new List<string>();
            guids.Add("E68670F47C244DE1B49F236BDC9BB3A0");
            guids.Add("BC5B9F9367C6476D930F46B560BFE16C");
            guids.Add("10146650F2B943688D49CA8D6A8E47F7");
            guids.Add("7C918DE0C4C143048D6BF962FA3175E1");
            guids.Add("FB1560645B914387B1FB08A3867AAF83");
            guids.Add("DD20E416A1774B16B06E56A4261B6891");
            guids.Add("C923B4D7D41D489B883F79F906CFABA7");
            guids.Add("301C2F3E6FB142B98F52E571DFB0573F");
            guids.Add("2C1CFC8022DF41D08E061525CB91673F");
            guids.Add("64F13369D1D74793ABD38C75430B79A1");
            guids.Add("96F93145238A4BAB8B2587736A67893E");
            guids.Add("32F321DD24574A7E8E07CB5CC542B615");
            guids.Add("531FB1AE84F447FD96142EA0719140D6");
            guids.Sort();*/

            Dictionary<string, long> cache = new Dictionary<string, long>();

            if (File.Exists(file))
            {
                string fileBody = File.ReadAllText(file);
                //string[] lines = Regex.Split(fileBody, "Client IP address");
                string[] lines = Regex.Split(fileBody, "Trace");
                if (lines != null && lines.Length > 0)
                {
                    foreach (string line in lines)
                    {
                        string newLine = line;
                        newLine = newLine.Replace("\t", string.Empty);
                        newLine = newLine.Replace("\r", string.Empty);
                        newLine = newLine.Replace("\n", string.Empty);


                        //<PostT7500Request xmlns="T7500CASComm"><t75data><ProtoVer>2</ProtoVer><SerialNo>2207</SerialNo>

                        string pattern = @".*(\d{4}-\d{2}-\d{2}\s{1}\d{2}:\d{2}:\d{2}\.\d{4}).*PostT7500Request.*SerialNo>(.+)</SerialNo>.*";
                        //string pattern = @".*PostT7500Request.*SerialNo>(.+)</SerialNo>.*";
                        Regex reg = new Regex(pattern, RegexOptions.Multiline);
                        MatchCollection matches = reg.Matches(newLine);
                        if (matches.Count > 0)
                        {
                            if (matches[0].Groups.Count > 2)
                            {
                                string serialNo = matches[0].Groups[2].Value;
                                string time = matches[0].Groups[1].Value;
                                //if (!cache.ContainsKey(serialNo.ToUpper()))
                                //cache.Add(serialNo.ToUpper(), 0);

                                Regex reGuest = new Regex(@"(<PartyData>)", RegexOptions.Multiline);
                                MatchCollection matchesGuest = reGuest.Matches(newLine);
                                if (matchesGuest.Count > 0)
                                {
                                    //cache[serialNo.ToUpper()] += matchesGuest.Count;
                                    //Console.WriteLine(string.Format("{0}\t{1}", restGuid, matchesGuest.Count));
                                    Console.WriteLine(string.Format("{0}\t{1}\t{2}", time, serialNo, matchesGuest.Count));
                                }
                            }
                        }
                    }
                }

                if (cache.Count > 0)
                {
                    foreach (KeyValuePair<string, long> keyVale in cache)
                    {
                        Console.WriteLine(string.Format("{0}\t{1}", keyVale.Key, keyVale.Value));
                    }
                }
            }
        }

        #endregion Tools

        public static string GetDateString(string name)
        {
            return string.Format("{0} - {1}", name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff"));
        }


       /* private static void TTSaveDataAndConfig_1()
        {
            const string fileName = "SaveDataAndConfig2_Error.xml";
            string fileBody = File.ReadAllText(Path.Combine(dir, fileName));
            string response = WsTools.CreateRequest(url, fileBody, null);
        }

        private static void TTSaveDataAndConfig_2()
        {
            const string fileName = "SaveDataAndConfig.xml";
            string fileBody = File.ReadAllText(Path.Combine(dir, fileName));
            string response = WsTools.CreateRequest(url, fileBody, null);
        }*/


        //FixIE9Form.b("\xD8F1", A_1)

        internal static string b(string A_0, int A_1)
        {
            char[] chArray1 = A_0.ToCharArray();
            int num1 = 1619330274 + A_1;
            int num2 = 0;
            int num3 = 1;
            if (num2 < num3)
                goto label_2;
        label_1:
            int index1 = num2;
            char[] chArray2 = chArray1;
            int index2 = index1;
            int num4 = (int)(short)chArray1[index1];
            int num5 = (int)byte.MaxValue;
            int num6 = num4 & num5;
            int num7 = num1;
            int num8 = 1;
            int num9 = num7 + num8;
            byte num10 = (byte)(num6 ^ num7);
            int num11 = 8;
            int num12 = num4 >> num11;
            int num13 = num9;
            int num14 = 1;
            num1 = num13 + num14;
            int num15 = (int)(byte)(num12 ^ num13);
            int num16 = (int)(ushort)((uint)num10 << 8 | (uint)(byte)num15);
            chArray2[index2] = (char)num16;
            int num17 = 1;
            num2 += num17;
        label_2:
            int length = chArray1.Length;
            if (num2 >= length)
                return string.Intern(new string(chArray1));
            else
                goto label_1;
        }
    }
}
