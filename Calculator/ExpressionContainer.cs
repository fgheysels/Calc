using System;
using System.Collections.Generic;
using Operators;
using System.ComponentModel.Composition;
namespace Calculator
{

    internal class ExpressionContainer : IPartImportsSatisfiedNotification
    {
        [ImportMany(typeof(IExpression), AllowRecomposition = true, RequiredCreationPolicy = CreationPolicy.NonShared)]
        internal IEnumerable<IExpression> _expressionImports;

        private static  readonly Dictionary<string, Type> _expressions = new Dictionary<string, Type>();

        internal static Type GetExpressionForOperator(string @operator)
        {
            if (_expressions.ContainsKey(@operator) == false)
            {
                throw new NotSupportedException($"{@operator} is not a supported operator");
            }

            return _expressions[@operator];            
        }


        public void OnImportsSatisfied()
        {
            // This method is called when all Imports have been resolved.
            // Right now, we've a collection of resolved instances; using these instances,
            // we'll populate our dictionary which contains the types that correspond with each symbol.

            _expressions.Clear();

            foreach (var e in _expressionImports)
            {
                var symbol = OperatorAttribute.GetOperator(e);

                if (symbol != String.Empty)
                {
                    if (_expressions.ContainsKey(symbol) == false)
                    {
                        _expressions.Add(symbol, e.GetType());
                    }
                }
            }
        }
    }
}