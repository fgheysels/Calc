namespace Operators
{
    public abstract class BinaryExpression : IExpression
    {
        private readonly IExpression _left;
        private readonly IExpression _right;

        protected  BinaryExpression()
        {   
        }

        public IExpression Left
        {
            get { return _left; }
        }

        public IExpression Right
        {
            get { return _right; }
        }

        protected BinaryExpression(IExpression l, IExpression r)
        {
            _left = l;
            _right = r;
        }

        public int Eval()
        {
            return EvalCore(_left.Eval(), _right.Eval());
        }

        protected abstract int EvalCore(int left, int right);

    }
}