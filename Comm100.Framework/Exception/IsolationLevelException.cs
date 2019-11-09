using System;
using System.Collections.Generic;
using System.Text;

namespace Comm100.Runtime.Exception
{
    public class IsolationLevelException:Comm100Exception
    {
        public IsolationLevelException() : base(100104, ErrorMessages.E100104)
        {

        }
    }
}
