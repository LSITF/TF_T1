using System;
using System.IO;
using ConApp_VS2k8.iQueue;

namespace ConApp_VS2k8
{
    public class iQueueTest
    {
        public static void SaveSectionBackground()
        {
            string guid = "576-416-218";
            string ver = "1.0.1";
            string sectionUid = "TF_sectionUid";
            string path = @"d:\!TF\DOC\D3ParagonLevelChart.jpg";
            byte[] fileData = File.ReadAllBytes(path);
            ActionReturnOfSaveSectionBackgroundReturn ret = new GuestConnect().SaveSectionBackground(guid, ver, sectionUid, fileData);
            if (ret != null && ret.Status == ActionReturnStatusEnumOfSaveSectionBackgroundReturn.OK)
                Lsi.Libs.LsiNLogger.LsiLogger.Trace("SaveSectionBackground:OK");
        }

        public static void GetSectionBackground()
        {
            string guid = "576-416-218";
            string ver = "1.0.1";
            string sectionUid = "TF_sectionUid";
            string dir = @"d:\!TF\DOC";
            string fileName = string.Format("SectionBackground_{0}.jpeg", DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            ActionReturnOfGetSectionBackgroundReturn ret = new GuestConnect().GetSectionBackground(guid, ver, sectionUid);
            if (ret != null && ret.Status == ActionReturnStatusEnumOfGetSectionBackgroundReturn.OK)
            {
                Lsi.Libs.LsiNLogger.LsiLogger.Trace("GetSectionBackground:OK");
                File.WriteAllBytes(Path.Combine(dir, fileName), ret.AddData.File);
            }
        }
    }
}
