//-----------------------------------------------------------------------
// <copyright file="BaseException.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Framework.Exception
{
    using System.Runtime.Serialization;

    public class BaseException:System.Exception
    {
        public int ErrorCode { get; protected set; }

        public BaseException(int errorCode)
        {
            ErrorCode = errorCode;
        }

        public BaseException(int errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }

        public BaseException(int errorCode, string message, System.Exception innerException) : base(message, innerException)
        {
            ErrorCode = errorCode;
        }

        protected BaseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
