using System;

public class Display
{
    private string Output;
    public Display(){
        SetOutput("0");
    }
    public string ShowOutput()
    {
        return Output;
    }
    public void SetOutput(string newOutput)
    {
        Output = newOutput;
    }
}
