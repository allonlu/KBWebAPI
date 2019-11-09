using System;
using System.Collections.Generic;
using System.Text;

namespace Comm100.Runtime.Exception
{
    public class WrongSoringException:Comm100Exception
    {
        public WrongSoringException() : base(100103, ErrorMessages.E100103) { }
    }
}
