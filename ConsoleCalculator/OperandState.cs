namespace ConsoleCalculator {
    class OperandState {
        public const string Error = "-E-";
        public string content;

        public OperandState () {
            this.Set("");
        }

        public void Set(string s) {
            content = s;
        }

        public string AddAndReturn(char key) {
            this.content += key;
            CheckForMultipleDotsOrZeroes();
            return this.content;
        }

        public void CheckForMultipleDotsOrZeroes() {
            if (content.Length == 1) 
                return;
            
            if (content[0] == '0' && content[1] != '.') 
                RemoveFirstCharacter();
            
            if (content[content.Length-1] == '.' && content[content.Length-2] == '.') 
                RemoveLastCharacter();
        }

        public string ToggleSignAndReturn() {
            switch(content) {
                case "":
                    this.Set("-");
                    break;
                case string s when s[0] == '-':
                    this.RemoveFirstCharacter();
                    break;
                default:
                    this.Set($"-{content}");
                    break;
            }

            return content;
        }

        public static string GetResult(float num1, float num2, char op) {
            switch (op) {
                case '+': return  (num1 + num2).ToString();
                case '-': return (num1 - num2).ToString();
                case 'x': 
                case 'X': return (num1 * num2).ToString();
                case '/': return  num2 == 0? "error": (num1 / num2).ToString();
                default: return "error";
            }
        }

        public void RemoveFirstCharacter() {
            this.Set(content.Substring(1));
        }

        public void RemoveLastCharacter() {
            this.Set(content.Substring(0, content.Length-1));
        }

        public void Clean() {
            if (content == ".") {
                this.Set("0.");
            }
        }
    }
}