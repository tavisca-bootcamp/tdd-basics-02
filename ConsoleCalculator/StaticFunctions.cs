namespace ConsoleCalculator {
    class StaticFunctions {
        public static char LastCharacterOf(string s) {
            return s[s.Length - 1];
        }

        public static void ToggleSign(ref string number) {
            if (float.TryParse(number, out float n)) {
                number = (-1 * n).ToString();
            }
        }
    }
}