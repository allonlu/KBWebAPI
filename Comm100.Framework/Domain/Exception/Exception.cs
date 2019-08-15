using Comm100.Runtime.Exception;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comm100.Domain.Exception
{
    public static class ExceptionCode
    {
        public static string E130001 = "Include不支持{0}的参数值！";
        public static string E130002 = "Id为{0}的{1}对象下，已经存在了Id为{2}的{3}！";
        public static string E130003 = "{0},操作被拒绝！";
    }
    public class WrongIncludeException : Comm100Exception
    {
        private readonly string value;

        public WrongIncludeException(string value) : base(130001, ExceptionCode.E130001) { this.value = value; }
        public override string Message => string.Format(base.Message,value);
    }
    public class ChildExistedException : Comm100Exception
    {
        private readonly string parentObject;
        private readonly Guid parentId;
        private readonly string childObject;
        private readonly Guid childId;

        public ChildExistedException(string parentObject,Guid parentId,string childObject,Guid childId) : base(130002, ExceptionCode.E130002) {
            this.parentObject = parentObject;
            this.parentId = parentId;
            this.childObject = childObject;
            this.childId = childId;
        }
        public override string Message => string.Format(base.Message,parentId,parentObject,childId,childObject);
    }
    public class OperationRefusedException : Comm100Exception
    {
        private readonly string reason;

        public OperationRefusedException(string reason) : base(130003, ExceptionCode.E130003) {
            this.reason = reason;
        }
        public override string Message =>string.Format(base.Message,reason);
    }
}
