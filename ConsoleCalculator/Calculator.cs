using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        ResultState resultState;
        OperandState operandState;
        State currentState, staleState;
        char? previousOperator;
        
        public Calculator() {
            // System.Console.WriteLine('0');
            resultState = new ResultState();
            operandState = new OperandState();

            currentState = resultState;
            staleState = operandState;

            previousOperator = null;
        }
        public string SendKeyPress(char key)
        {   
            try
            {
                return currentState.Feed(key);
            }
            catch (ArgumentOutOfRangeException)
            {
                if (State.IsOperator(key)) 
                {
                    if (previousOperator == null) 
                    {
                        this.SwitchStates();
                        previousOperator = key;
                        return staleState.inputHolder.ToString();
                    }

                    return GetResult(key);
                }
                
                if (State.IsEqualsSign(key))
                {
                    return GetResult(null);
                }
                
                if (State.IsClearSign(key))
                {
                    this.ClearScreen();
                    this.ClearMemory();
                    return currentState.inputHolder.ToString();
                }
            }
            return currentState.inputHolder;
        }

        public string GetResult(char? currentOperator)
        {
            var result = State.EvaluateExpression(staleState, currentState, previousOperator.Value);

            ClearMemory();
            ClearScreen();

            if (result == State.Error) return result;

            currentState.inputHolder = result;
            previousOperator = currentOperator;
            
            if (currentOperator != null) this.SwitchStates();
            return result;
        }

        public void SwitchStates() 
        {
            var temp = currentState;
            currentState = staleState;
            staleState = temp;
        }

        public void ClearMemory() 
        {
            previousOperator = null;
        }

        public void ClearScreen()
        {
            resultState.Clear();
            operandState.Clear();

            currentState = resultState;
            staleState = operandState;
        }
    }
}
