using System;
using System.ComponentModel.Composition;
using Operators;

namespace ExpressionPack
{
    [Export(typeof(IExpression))]
    [Operator("^")]
    public sealed class Pow : BinaryExpression
    {
        private Pow()
        {
            
        }

        public Pow(IExpression left, IExpression right) : base(left, right)
        {            
        }

        protected override int EvalCore(int left, int right)
        {
            return (int)Math.Pow(left, right);
        }
    }
}
