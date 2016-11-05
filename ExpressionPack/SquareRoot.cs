using System;
using System.ComponentModel.Composition;
using Operators;

namespace ExpressionPack
{
    [Export(typeof(IExpression))]
    [Operator("sqrt")]
    public sealed class SquareRoot : UnaryExpression
    {
        private SquareRoot()
        {            
        }

        public SquareRoot(IExpression expr) : base(expr)
        {
        }

        protected override int EvalCore(int operand)
        {
            return (int) Math.Sqrt(operand);
        }
    }
}
