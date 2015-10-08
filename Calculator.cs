using CalculatorStaffSolution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorSolution
{
    /// <summary>
    /// This is the calculator class that you will use to complete your assignment.  Note that
    /// certain methods have already been crafted.  This provides some input on how to 
    /// proceed with this assessed component.
    /// 
    /// Good luck!
    /// 
    /// Tommy and Dave.
    /// </summary>
    public class Calculator
    {
        /**
         * Here are some basic variables to help us get running.
         */
        double accumulator;
        double previousOperand;
        char previousOperation;
        const string Error = "ERROR";

        /**
         * We have a collection of other useful boolean variables here.  You can try to
         * use these as part of your work to dicate the structure of execution.
         */
        bool errorFound;
        bool calculationStarted;
        bool awaitingOperation;
        bool calculationComplete;

        /// <summary>
        /// Moves through the next step of the calculators process.
        /// </summary>
        /// <param name="operand">The number that a particular operation is committed to.</param>
        /// <param name="operation">The next operation we wish to run.</param>
        /// <returns>The current value of the calculation.</returns>
        public string Calculate(double operand, char operation)
        {
            //Assume no failure until we find one!
            errorFound = false;
            calculationComplete = false;

            //Run any pending calculations
            if (awaitingOperation)
            {
                //Run the operation we still need to run.
                RunOperation(operand, previousOperation);
            }

            //implement something to return a value.







            //Run any terminal operations (e.g. =) if needed.
            if (IsTerminalOperation(operation))
            {
                RunTerminalOperation(operation);

                //We won't be awaiting further computation.
                awaitingOperation = false;

                //And this calculation is done!
                calculationComplete = true;
            }
            else
            {
                //Store the operator and set the output.
                previousOperand = operand;
                previousOperation = operation;
                awaitingOperation = true;
            }

            //Run either an error or the actual output.
            if (errorFound)
            {
                ResetCalculator();
                return Error;
            }
            else
            {
                if (calculationComplete)
                {
                    string result = accumulator.ToString();
                    ResetCalculator();
                    return result;
                }
                else
                {
                    return accumulator.ToString();
                }
            }
        }

        private void ResetCalculator()
        {
            //Reset all of the variables that you need for this calculator.
        }


        /// <summary>
        /// Determines whether a calculator operation is terminal.
        /// </summary>
        /// <param name="operation">The operator in question.</param>
        /// <returns>True if terminal, false otherwise.</returns>
        private bool IsTerminalOperation(char operation)
        {
            if (operation == '=')
            {
                return true;
            }

            return false;
        }

        private void RunTerminalOperation(char operation)
        {
            double input = SelectInput();

            switch (operation)
            {
                case '=':
                default: break;
            }
        }


        /// <summary>
        /// Figures out which is the calculation that we need to
        /// complete and then runs it.
        /// </summary>
        /// <param name="operand">The operand from the last statement.</param>
        /// <param name="operation">The operation we wish to run.</param>
        private void RunOperation(double operand, char operation)
        {
            double result = 0;

            double input = SelectInput();

            switch (operation)
            {
                case '+':
                    result = Add(input, operand);
                    accumulator = result;
                    break;

                case '-':
                    result = Subtract(input, operand);
                    accumulator = result;
                    break;

                case '*':
                    result = Multiply(input, operand);
                    accumulator = result;
                    break;

                case '/':
                    result = Divide(input, operand);
                    accumulator = result;
                    break;

                default: break;
            }
        }

        /// <summary>
        /// Decides which input is the one needed for this 
        /// calculation?
        /// </summary>
        /// <returns>The input we need for this calculation.</returns>
        private double SelectInput()
        {
            double input;

            //Is the input *always* going to be the previous operand?
            input = previousOperand;
            return input;
        }
     
        /// <summary>
        /// Calculates the addition of two numbers.
        /// </summary>
        /// <param name="number1">The first number in the operation.</param>
        /// <param name="number2">The second number in the operation.</param>
        /// <returns>The result of the addition, rounded to two decimal places.</returns>
        private double Add(double number1, double number2)
        {
            double result = number1 + number2;
            result = Math.Round(result, 2);
            return result;
        }

        private double Subtract (double number1, double number2)
        {
            double result = number1 - number2;
            result = Math.Round(result, 2);
            return result;
        }

        private double Multiply(double number1, double number2)
        {
            double result = number1 * number2;
            result = Math.Round(result, 2);
            return result;
        }

        private double Divide(double number1, double number2)
        {
            double result = number1 / number2;
            result = Math.Round(result, 2);
            return result;
        }


    }
}
