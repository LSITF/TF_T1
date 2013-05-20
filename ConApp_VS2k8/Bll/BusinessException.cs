using System;
using System.Runtime.Serialization;
using Lsi.Libs.LsiNLogger;

namespace ConApp_VS2k8.Bll
{
    [Serializable]
    public class BusinessException : ApplicationException, ISerializable
    {
        public static string InternalError = "Internal error.";

        public enum BusinessExcTypeEnum
        {
            /// <summary>
            /// Don't use it!
            /// </summary>
            None = 0,
            Error = 1, 
            Warning = 2
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessException"/> class.
        /// </summary>
        public BusinessException (String message, Exception ex) : base(message, ex)
        {
            LsiLogger.ErrorException(string.Format("Lsi.WaiterLocatorDb.WaiterLocatorDbWebBll.BllExceptions.BusinessException(string, exception) with message:{0}", message), ex);
            this.messages = new string[] { message };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessException"/> class.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <param name="context">The context.</param>
        internal BusinessException (SerializationInfo info, StreamingContext context)
            : base (info, context)
        {
            this.messages = (string[])info.GetValue("messages", typeof(string[]));
            this.exceptionType = (BusinessExcTypeEnum)info.GetInt32("extype");
        }

        private readonly string[] messages;
        private readonly BusinessExcTypeEnum exceptionType;


        //NOTE: Constructors commented out by lknop on 25/05/2009, removed reference to lsidblayer
        //NOTE: RetrieWL of messages from StoreProcException is handled in BusinessExceptionFactory
        // internal BusinessException (StoreProcException ex)
        // internal BusinessException (StoreProcException ex, Exception innerException)

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessException"/> class. Invoked from
        /// <see cref="BusinessExceptionFactory" /> which converts user-friendly messages from DB
        /// to upper layers.
        /// </summary>
        /// <param name="messages">The messages array</param>
        /// <param name="original">The original exception, used as the source of description and stacktrace.
        /// Cannot be null!</param>
        /// <param name="exceptionType">Type of the exception (subtle warning or full-blown error)</param>
        internal BusinessException(string[] messages, Exception original, BusinessExcTypeEnum exceptionType)
            : base(original.Message, original.InnerException)
        {
            this.exceptionType = exceptionType;
            this.messages = messages;
        }


        /// <summary>
        /// Gets the type of the exception - whether it's error or warning
        /// </summary>
        /// <Value>The type of the exception.</Value>
        public BusinessExcTypeEnum ExceptionType
        {
            get { return exceptionType; }
        }

        /// <summary>
        /// Gets the all error messages.
        /// </summary>
        /// <Value>The messages.</Value>
        public string[] Messages
        {
            get { return messages; }
        }

        #region ISerializable Members

        /// <summary>
        /// When overridden in a derived class, sets the <see cref="T:System.Runtime.Serialization.SerializationInfo"/> 
        /// with information about the exception.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the 
        /// serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains 
        /// contextual information about the source or destination.</param>
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("messages", messages);
            info.AddValue("extype", (int)exceptionType);
            base.GetObjectData(info, context);
        }

        #endregion
    }
}