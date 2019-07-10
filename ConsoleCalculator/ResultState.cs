namespace ConsoleCalculator {
    class ResultState: State 
    { 
        public void Clear()
        {
            this.inputHolder = string.Empty;
            this.isNegative = false;
            this.SetToZero();
        }

        public void SetToZero()
        {
            this.inputHolder = "0";
        }
    }
}