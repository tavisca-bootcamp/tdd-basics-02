using System;

public class Operator
{
    public char Symbol;
    public Operator()
    {
        Symbol = ' ';
    }
    public void SetOperator(char newOperator)
    {
        Symbol = newOperator;
    }
    public char GetOperator()
    {
        return Symbol;
    }
}
