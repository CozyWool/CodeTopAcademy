using System;

namespace ExpressionParser
{
    public class Parser
    {
        public int Parse(string expression)
        {
            int pos;
            if ((pos = expression.IndexOf('+')) != -1)
            {
                var leftOperand = Parse(expression.Substring(0, pos));
                var rightOperand = Parse(expression.Substring(pos + 1));
                return leftOperand + rightOperand;
            }

            if ((pos = expression.IndexOf('-')) != -1)
            {
                var leftOperand = Parse(expression.Substring(0, pos));
                var rightOperand = Parse(expression.Substring(pos + 1));
                return leftOperand - rightOperand;
            }

            if ((pos = expression.IndexOf('*')) != -1)
            {
                var leftOperand = Parse(expression.Substring(0, pos));
                var rightOperand = Parse(expression.Substring(pos + 1));
                return leftOperand * rightOperand;
            }

            if ((pos = expression.IndexOf('/')) != -1)
            {
                var leftOperand = Parse(expression.Substring(0, pos));
                var rightOperand = Parse(expression.Substring(pos + 1));
                return leftOperand / rightOperand;
            }
                
            return Convert.ToInt32(expression);
        }
    }
}
