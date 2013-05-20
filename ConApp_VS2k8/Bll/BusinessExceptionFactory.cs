using System.Collections.Generic;
using Lsi.Libs.LsiDbLayer;
using Lsi.Libs.LsiNLogger;

namespace ConApp_VS2k8.Bll
{
    internal static class BusinessExceptionFactory
    {

        internal static BusinessException CreateNew(StoreProcException ex)
        {
            LsiLogger.ErrorException("Lsi.PlayPaq.PlayPaqWebBll.BllExceptions.BusinessExceptionFactory.CreateNew()", ex);
            List<string> messs = new List<string>();
            if (ex is SpNonZeroReturnException || ex is NoSingleRowReturnedException)
                return new BusinessException(new string[] { BusinessException.InternalError }, ex, BusinessException.BusinessExcTypeEnum.Error);
            foreach (StoreProcException.SingleException error in ex.AllErrors)
                messs.Add(error.ErrorMessage);
            string[] messages = new string[messs.Count];
            messs.CopyTo(messages);
            BusinessException.BusinessExcTypeEnum exceptionType = (ex.HasLsiErrors || ex.HasSqlErrors
                                                                       ? BusinessException.BusinessExcTypeEnum.Error
                                                                       : BusinessException.BusinessExcTypeEnum.Warning);

            return new BusinessException(messages, ex, exceptionType);
        }
    }
}