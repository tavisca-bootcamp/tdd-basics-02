using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        private ResultState resultState;
        private OperandState operandState;
        private char? operatorValue;
        private State currentState, stableState;

        public Calculator()
        {
            resultState = new ResultState();
            operandState = new OperandState();
            operatorValue = null;

            currentState = resultState;
            stableState = operandState;
        }

        public string SendKeyPress(char key)
        {
            try
            {
                return currentState.InputFeed(key);
            }
            catch (Exception)
            {
                if (State.IsClearSign(key))
                {
                    this.ClearMemory();
                    return currentState.input;
                }

                if (State.IsOperator(key))
                {
                    if (operatorValue == null)
                    {
                        this.SwitchStates();
                        operatorValue = key;
                        return stableState.input;
                    }

                    return GetResult(key);
                }

                if (State.IsEqualsSign(key))
                {
                    return GetResult(null);
                }
                else
                    return currentState.input;
            }
        }

        public void ClearMemory()
        {
            resultState.Clear();
            operandState.Clear();
            operatorValue = null;
            currentState = resultState;
            stableState = operandState;
        }

        public string GetResult(char? ch)
        {
            var result = State.EvaluateResult(stableState, currentState, operatorValue);

            if (result == State.Error) return result;

            this.ClearMemory();

            currentState.input = result;
            operatorValue = ch;

            if (operatorValue != null)
                this.SwitchStates();

            return currentState.input;
        }

        public void SwitchStates()
        {
            var tempState = currentState;
            currentState = stableState;
            stableState = tempState;
        }
    }
}
