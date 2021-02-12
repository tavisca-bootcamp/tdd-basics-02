namespace ConsoleCalculator 
{
    class OperandState: State 
    {
        public void Clear()
        {
            this.inputHolder = string.Empty;
            this.isNegative = false;
        }
    }
}