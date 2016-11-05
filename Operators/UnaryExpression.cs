namespace Operators
{
    public abstract class UnaryExpression : IExpression
    {
        private readonly IExpression _expression;

        protected UnaryExpression()
        {
            
        }

        public IExpression Operand
        {
            get { return _expression; }
        }


        protected UnaryExpression(IExpression expr)
        {
            _expression = expr;
        }

        public int Eval()
        {
            return EvalCore(_expression.Eval());
        }

        protected abstract int EvalCore(int operand);
    }
}