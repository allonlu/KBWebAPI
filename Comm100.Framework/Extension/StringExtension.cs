using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comm100.Extension
{
    public static class StringExtension
    {
        public static string[] AnalyzeInclude(this string include)
        {
            if (string.IsNullOrWhiteSpace(include)) return new string[0];

            return include.Split(',').Select(e => e.ToLower()).ToArray();
        }
    }
}
