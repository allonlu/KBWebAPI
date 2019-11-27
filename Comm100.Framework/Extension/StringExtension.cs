namespace Comm100.Framework.Extension
{
    using System;
    using System.Linq;

    public static class StringExtension
    {
        public static string[] AnalyzeInclude(this string include)
        {
            if (string.IsNullOrWhiteSpace(include)) return new string[0];

            return include.Split(',').Select(e => e.ToLower()).ToArray();
        }

        public static T ParseEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
