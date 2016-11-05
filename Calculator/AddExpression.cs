using System;
using System.ComponentModel.Composition;
using Operators;

namespace Calculator
{
    [Export(typeof(IExpression))]
    [Operator("+")]
    public sealed class AddExpression : BinaryExpression
    {
        private  AddExpression()
        {                
        }

        public AddExpression(IExpression left, IExpression right) : base(left, right)
        {
        }
      
        protected override int EvalCore(int left, int right)
        {
            return left + right;
        }
    }
}