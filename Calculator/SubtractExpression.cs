using System.ComponentModel.Composition;
using Operators;

namespace Calculator
{
    [Export(typeof(IExpression))]
    [Operator("-")]
    public sealed class SubtractExpression : BinaryExpression
    {
        private SubtractExpression()
        {
            // Default ctor is needed for MEF.            
        }

        public SubtractExpression(IExpression l, IExpression r) : base(l, r)
        {
        }

        protected override int EvalCore(int left, int right)
        {
            return left - right;
        }
    }
}