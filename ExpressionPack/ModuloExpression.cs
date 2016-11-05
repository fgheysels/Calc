using System.ComponentModel.Composition;
using Operators;

namespace ExpressionPack
{
    [Operator("%")]
    [Export(typeof(IExpression))]
    public sealed class ModuloExpression : BinaryExpression
    {
        private ModuloExpression()
        {
        }

        public ModuloExpression(IExpression left, IExpression right) : base(left, right)
        {
        }

        protected override int EvalCore(int left, int right)
        {
            return left % right;
        }
    }
}
