using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class QueryExtensions
    {
        public static string ConditionalQuery(string className, string propriedade, object value)
        {
            return $"SELECT * FROM \"{className}_tb\" WHERE \"{propriedade}\" = '{value}'";
        }
    }
}
