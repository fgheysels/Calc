using System.Text;
using Operators;

namespace Calculator
{
    interface IExpressionVisitor
    {
        void Visit(IExpression expr);

        ////void Visit(ConstantExpression expr);

        ////void Visit(BinaryExpression expr);

        ////void Visit(UnaryExpression expr);
    }

    public class InfixVisitor : IExpressionVisitor
    {
        private readonly StringBuilder result = new StringBuilder();

        public void Visit(IExpression expr)
        {
            // The dynamic keyword removes the need for the double dispatch which is 
            // described in the GoF Visitor pattern.
            // Without dynamic, we'd need an 'Accept' method on Expression class
            // which makes sure that the correct Visit method would be called.
            dynamic e = expr;
            Visit(e);
        }

        private void Visit(ConstantExpression expr)
        {
            result.Append(expr.Eval());
        }

        private void Visit(BinaryExpression expr)
        {
            result.Append("(");
            Visit(expr.Left);
            result.Append(" " + OperatorAttribute.GetOperator(expr) + " ");
            Visit(expr.Right);
            result.Append(")");
        }

        private void Visit(UnaryExpression expr)
        {
            Visit(expr.Operand);
            result.Append(OperatorAttribute.GetOperator(expr));
        }

        public override string ToString()
        {
            return result.ToString();
        }
    }
}
