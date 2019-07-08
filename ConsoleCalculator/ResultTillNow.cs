using System;

public class ResultTillNow
{
    double Value;
    string Result;
	public ResultTillNow()
	{
        Value = 0;
        Result="0";
	}
    public void SetValue(string newValue)
    {
        Value = Double.Parse(newValue);
        Result=newValue;
    }
    public string GetValue()
    {
        return Result;
    }
    public void Operate(char operation,string operand)
    {
        if (operation == '+'){
            Value += Double.Parse(operand);
            Result=Value.ToString();
        }
        else if (operation == '-'){
            Value -= Double.Parse(operand);
            Result=Value.ToString();
        }
        else if(operation=='x' || operation == 'X'){
            Value *= Double.Parse(operand);
            Result=Value.ToString();
        }
        else if(operation=='/'){
            if(Double.Parse(operand)==0){
                Value=0;
                Result="-E-";
            }
            else{
                Value /= Double.Parse(operand);
                Result=Value.ToString();
            }
        }
        else {
            Value=Double.Parse(operand);
            Result=operand;
        }
    }
}
