using System;
using System.Collections.Generic;
using System.Text;

namespace Comm100.Extension
{
   public static class CheckerExtension
    {
        public static T NotNull<T>(this T value, string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            return value;
        }
        public static string NotNullOrWhiteSpace(this string value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(string.Format("{0} can not be null, empty or white space!", parameterName));
            }

            return value;
        }

        public static ICollection<T> NotNullOrEmpty<T>(this ICollection<T> value, string parameterName)
        {
            if (value == null || value.Count <= 0)
            {
                throw new ArgumentException(parameterName + " can not be null or empty!", parameterName);
            }

            return value;
        }
    }
}
