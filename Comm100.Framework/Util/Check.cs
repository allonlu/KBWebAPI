using System;
using System.Diagnostics.CodeAnalysis;

namespace Comm100.Framework.Util
{
    public class Check
    {
        public static T NotNull<T>(T value, [NotNull] string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentException(parameterName);
            }
            return value;
        }
    }
}
