using System.ComponentModel.Composition;
using Operators;

namespace ExtraOperators
{
    [Export(typeof(IExpression))]
    [Operator("/")]
    public sealed class DivideExpression : BinaryExpression
    {

        private DivideExpression()
        {
            
        }
       
        public DivideExpression(IExpression l, IExpression r) : base(l, r)
        {
        }

        protected override int EvalCore(int left, int right)
        {
            return left / right;
        }
    }
}