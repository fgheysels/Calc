using System;
using System.Reflection;

namespace Operators
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class OperatorAttribute : Attribute
    {
        public string Symbol { get; private set; }

        public OperatorAttribute(string symbol)
        {
            this.Symbol = symbol;
        }

        public static string GetOperator(object o)
        {
            Type t = o.GetType();
            return GetOperator(t);
        }

        public static string GetOperator(Type t)
        {
            var attr = t.GetCustomAttribute<OperatorAttribute>();

            if (attr != null)
            {
                return attr.Symbol;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
