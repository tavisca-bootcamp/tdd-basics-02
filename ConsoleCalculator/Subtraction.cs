using System;

public class Subtraction : Operation
{

    public string DoCalculation(double operandOne, double operandTwo)
    {
        double temp = operandOne - operandTwo;

        if (temp % 1 != 0.0)
            return temp.ToString();
        int result = (int)temp;
        return result.ToString();

    }
}
