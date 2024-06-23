using System;

namespace FirstHomeWorkWpfApp.Class;

public static class Parser
{
    public static double Parse(string expression)
    {
        int pos;
        if ((pos = expression.IndexOf('+')) != -1)
        {
            var leftOperand = Parse(expression[..pos]);
            var rightOperand = Parse(expression[(pos + 1)..]);
            return leftOperand + rightOperand;
        }

        if ((pos = expression.IndexOf('-')) != -1)
        {
            var leftOperand = Parse(expression[..pos]);
            var rightOperand = Parse(expression[(pos + 1)..]);
            return leftOperand - rightOperand;
        }

        if ((pos = expression.IndexOf('*')) != -1)
        {
            var leftOperand = Parse(expression[..pos]);
            var rightOperand = Parse(expression[(pos + 1)..]);
            return leftOperand * rightOperand;
        }

        if ((pos = expression.IndexOf('/')) != -1)
        {
            var leftOperand = Parse(expression[..pos]);
            var rightOperand = Parse(expression[(pos + 1)..]);
            return leftOperand / rightOperand;
        }
                
        return Convert.ToDouble(expression);
    }
}