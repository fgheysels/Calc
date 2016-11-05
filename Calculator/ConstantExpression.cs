using Operators;

namespace Calculator
{
    /// <summary>
    /// Represents a constant.
    /// </summary>
    public class ConstantExpression : IExpression
    {
        private readonly int _value;

        public ConstantExpression( int value)
        {
            _value = value;
        }

        public int Eval()
        {
            return _value;
        }
    }
}