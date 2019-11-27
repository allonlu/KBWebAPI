using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Domain.Entities
{
    public class Tag
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }
    }
}
