using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Comm100.Runtime.Exception
{
   public class Comm100Exception:System.Exception
    {
        public int ErrorCode { get; protected set; }

        public Comm100Exception(int errorCode)
        {
            ErrorCode = errorCode;
        }

        public Comm100Exception(int errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }

        public Comm100Exception(int errorCode, string message, System.Exception innerException) : base(message, innerException)
        {
            ErrorCode = errorCode;
        }

        protected Comm100Exception(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

}
