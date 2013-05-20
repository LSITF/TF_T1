using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Lsi.Libs.LsiNLogger;

namespace ConApp_VS2k8
{
    public class InfoObj
    {
        public int Line { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Result { get; set; }

        public override string ToString()
        {
            const string dateFormat = "yyyy-MM-dd HH:mm:ss.fff";
            return string.Format("{0};{1};{2};{3}", Line, Start.ToString(dateFormat), End.ToString(dateFormat), Result);
        }
    }

    public class SoapParser
    {
        public static bool Srv2SoapParser(string filePath)
        {
            Collection<InfoObj> infos = new Collection<InfoObj>();
            int lineCouinter = 1;
            bool retValue = false;
            if (File.Exists(filePath))
            {
                const string newLinePattern = @"^\[Trace\]\[\d{4}-\d{2}-\d{2}\s{1}\d{2}:\d{2}:\d{2}.\d{4}\].*";
                const string startRequestStr = "<SaveSurveyResult xmlns=\"Srv2\">";
                const string endRequestStr = "<SaveSurveyResultResponse xmlns=\"Srv2\">";

                Collection<string> origLines = ReadFileLines(filePath);
                Collection<string> lines = SplitFileByRegEx(origLines, newLinePattern);

                /*string fileBody = File.ReadAllText(filePath);
                string[] lines = new Regex(newLinePattern, RegexOptions.Multiline).Split(fileBody);*/
                if(lines != null && lines.Count > 0)
                //if (lines != null && lines.Length > 0)
                {
                    InfoObj info = null;
                    int loopCounter = 0;
                    foreach (string line in lines)
                    {
                        if(line.ToUpper().Contains(startRequestStr.ToUpper()))
                        {
                            if(info != null)
                                infos.Add(info);
                            info = new InfoObj();
                            info.Line = lineCouinter;

                            DateTime? startDate = GetDateFromLine(line);
                            if (startDate.HasValue)
                                info.Start = startDate.Value;

                            loopCounter++;
                            if (loopCounter == lines.Count && info != null)
                                infos.Add(info);
                            continue;
                        }

                        if (line.ToUpper().Contains(endRequestStr.ToUpper()))
                        {
                            if (info != null)
                            {
                                DateTime? endDate = GetDateFromLine(line);
                                if (endDate.HasValue)
                                    info.End = endDate.Value;

                                int? result = GetResultFromLine(line);
                                if (result.HasValue)
                                    info.Result = result.Value;

                            }
                            loopCounter++;
                            lineCouinter++;
                            if (loopCounter == lines.Count && info != null)
                                infos.Add(info);
                            continue;
                        }
                    }
                    StringBuilder sb = new StringBuilder();
                    if(infos.Count > 0)
                    {
                        foreach (InfoObj obj in infos)
                        {
                            sb.AppendLine(obj.ToString());
                        }
                    }
                    LsiLogger.Trace(sb.ToString(), "SOPA_Result");
                    retValue = true;
                }
            }
            else
                retValue = false;
            return retValue;
        }

        private static DateTime? GetDateFromLine(string line)
        {
            DateTime? returbnValue = null;
            string datePattern = @"^\[Trace\]\[(\d{4}-\d{2}-\d{2}\s{1}\d{2}:\d{2}:\d{2}.\d{4})\].*";
            MatchCollection matchColl = new Regex(datePattern).Matches(line);
            if (matchColl.Count > 0 && matchColl[0].Success
                && matchColl[0].Groups != null && matchColl[0].Groups.Count > 1)
            {
                string strDate = matchColl[0].Groups[1].ToString();
                DateTime date;
                if(DateTime.TryParse(strDate, out date))
                    returbnValue = date;
            }
            return returbnValue;
        }

        private static int? GetResultFromLine(string line)
        {
            int? returbnValue = null;
            string datePattern = @"^.*<ResultCode>(1)</ResultCode>.*$";
            MatchCollection matchColl = new Regex(datePattern).Matches(line);
            if (matchColl.Count > 0 && matchColl[0].Success
                && matchColl[0].Groups != null && matchColl[0].Groups.Count > 1)
            {
                string strResult = matchColl[0].Groups[1].ToString();
                int result;
                if (int.TryParse(strResult, out result))
                    returbnValue = result;
            }
            return returbnValue;
        }

        private static Collection<string> SplitFileByRegEx(Collection<string> fileLines, string regEx)
        {
            Collection<string> ret = new Collection<string>();
            //[Trace][2010-07-01 18:44:01.8438]Message:
            string newLine = string.Empty;
            int counter = 1;
            foreach (string fileLine in fileLines)
            {
                if (!string.IsNullOrEmpty(newLine) && !string.IsNullOrEmpty(fileLine) && new Regex(regEx).IsMatch(fileLine))
                {
                    ret.Add(newLine);
                    newLine = string.Empty;
                }
                newLine += fileLine;
                
                counter++;
                if(counter == fileLines.Count)
                    ret.Add(newLine);
            }
            return ret;
        }

        private static Collection<string> ReadFileLines(string fullPath)
        {
            Collection<string> lines = new Collection<string>();
            //using (StreamReader sr = new StreamReader(fullPath, Encoding.UTF8))
            using (StreamReader sr = new StreamReader(fullPath))
            {
                string strLine = String.Empty;
                while (strLine != null)
                {
                    strLine = sr.ReadLine();
                    lines.Add(strLine);
                }
                sr.Close();
            }
            return lines;
        }
    }
}
