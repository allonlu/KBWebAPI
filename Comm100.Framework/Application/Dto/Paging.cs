using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Comm100.Framework
{
    public class Paging
    {
        public int Index { get; set; }

        [Range(10, 100)]
        public int Size { get; set; }
    }
}
