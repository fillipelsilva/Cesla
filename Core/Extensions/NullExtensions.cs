using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class NullExtensions
    {
        public static bool IsNull<T>(this T @this) where T : class
        {
            return @this == null;
        }
    }
}
