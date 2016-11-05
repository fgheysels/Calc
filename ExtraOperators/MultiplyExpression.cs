using System.ComponentModel.Composition;
using Operators;
using BinaryExpression = Operators.BinaryExpression;

namespace ExtraOperators
{
    [Export(typeof(IExpression))]
    [Operator("*")]
    public sealed class MultiplyExpression : BinaryExpression
    {

        private MultiplyExpression()
        {
            
        }

        public MultiplyExpression(IExpression l, IExpression r) : base(l, r)
        {
        }

        protected override int EvalCore(int left, int right)
        {
            return left * right;
        }
    }
}

