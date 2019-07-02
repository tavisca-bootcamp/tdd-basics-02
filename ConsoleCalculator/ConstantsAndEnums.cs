namespace ConsoleCalculator {
    public enum States {
        NumberState,
        OperatorState
    }
    public enum Events {
        NumberFeed,
        SignFeed,
        OperatorFeed,
        DisplayResult,
        ClearScreen,
        Error
    }

    public static class Constants {
        public const string Numbers = "0123456789.";
        public const string Sign = "sS";
        public const string Operators = "+-xX/";
        public const string EqualsSign = "=";
        public const string ClearScreen = "cC";
    }
}