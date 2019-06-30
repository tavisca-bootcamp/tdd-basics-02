using System;

public class Character
{
    public static bool IsSymbol(char key)
    {
        switch (key)
        {
            case '+':
            case '-':
            case 'x':
            case 'X':
            case '/':
            case '=': return true;
            default: return false;
        }
    }

    public static bool IsDigit(char key)
    {
        return (key >= '0' && key <= '9') || key == '.';
    }

    public static  bool IsToggle(char key)
    {
        return key == 's' || key =='S' ;
    }

    public static bool IsSetZero(char key)
    {
        throw new NotImplementedException();
    }

}
