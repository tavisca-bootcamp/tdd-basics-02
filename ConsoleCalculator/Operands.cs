using System;

public class Operands
{
    public  string FirstOperand;
    public  string SecondOperand;
    public  Nullable<char> Symbol;
    public String UpdateOperands(char key)
    {
        String result;
        if (Symbol!=null)
        {
            SecondOperand = UpdateSpecificOperand(SecondOperand, key);
            result = SecondOperand;
        }
        else
        {
            FirstOperand = UpdateSpecificOperand(FirstOperand, key);
            result = FirstOperand;

        }
        return result;

    }
    private string UpdateSpecificOperand(string operand, char key)
    {
        switch (operand)
        {
            case var c when c == null: return key.ToString();
            case var c when c.Equals("0") && key == '0': return "0";
            default: return String.Concat(operand, key.ToString());
        }

    }
    public string ChangeSign()
    {
        string result;
        if (SecondOperand == null)
        {
            FirstOperand = Toggle(FirstOperand);
            result = FirstOperand;
        }
        else
        {
            SecondOperand = Toggle(SecondOperand);
            result = SecondOperand;
        }
        return result;

    }

    private string Toggle(string operand)
    {
        double temp = double.Parse(operand);
        temp = -temp;
        return temp.ToString();

    }

    public void Reset()
    {
        FirstOperand = null;
        SecondOperand = null;
        Symbol = null;
        
    }
}
