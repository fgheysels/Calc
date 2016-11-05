using System.ComponentModel.Composition;
using Operators;

namespace ExpressionPack
{
    // Types that should be imported by MEF (and treated as plugins) should be decorated with
    // the Export attribute.

    [Export(typeof(IExpression))]
    [Operator("!")]
    public sealed class Factorial : UnaryExpression
    {
        private Factorial()
        {
            
        }

        public Factorial(IExpression expr) : base(expr)
        {
        }

        protected override int EvalCore(int operand)
        {          
            int result = 1;

            for (int i = 1; i <= operand; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}