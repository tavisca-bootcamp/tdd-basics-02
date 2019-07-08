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
        //todo
    }
}
