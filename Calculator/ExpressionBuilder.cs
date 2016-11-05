using System;
using System.Collections.Generic;
using Operators;

namespace Calculator
{
    public static class ExpressionBuilder
    {
        public static IExpression CreateExpression(string input)
        {
            // Parse the input-string
            var tokens = Tokenize(input);

            var stack = new Stack<IExpression>();

            foreach (var t in tokens)
            {
                var expr = Create(t, stack);

                stack.Push(expr);
            }

            if (stack.Count == 1)
            {
                return stack.Pop();
            }
            else
            {
                throw new InvalidOperationException("Syntax error");
            }
        }

        private static IExpression Create(string token, Stack<IExpression> expressionStack)
        {
            int value;

            if (Int32.TryParse(token, out value))
            {
                return new ConstantExpression(value);
            }

            return GetExpression(token, expressionStack);
        }

        private static IExpression GetExpression(string symbol, Stack<IExpression> stack)
        {
            // use our container to retrieve the correct type that should be used for the
            // specified symbol (+, -, ...) 
            var type = ExpressionContainer.GetExpressionForOperator(symbol);

            if (typeof(UnaryExpression).IsAssignableFrom(type))
            {
                // When a unary-expression has been created, we only need one expression from the stack.
                var operand = stack.Pop();
                return Activator.CreateInstance(type, new object[] { operand }) as IExpression;
            }
            else if (typeof(BinaryExpression).IsAssignableFrom(type))
            {
                // Binary expressions need 2 operands.
                var right = stack.Pop();
                var left = stack.Pop();

                return Activator.CreateInstance(type, new object[] { left, right }) as IExpression;
            }
            else
            {
                throw new NotSupportedException($"Expression of type {type} not supported.");
            }

        }

        private static string[] Tokenize(string input)
        {
            return input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}