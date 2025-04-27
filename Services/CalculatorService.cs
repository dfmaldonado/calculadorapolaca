using Calculator.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Calculator.Services
{
    public class CalculatorService : ICalculatorService
    {
        public double EvaluateRPN(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
                throw new ArgumentException("La expresión RPN no puede estar vacía.");

            var stack = new Stack<double>();
            var tokens = expression.Split(' ');

            foreach (var token in tokens)
            {
                if (double.TryParse(token, out double number))
                {
                    stack.Push(number);
                }
                else
                {
                    if (stack.Count < 2)
                        throw new InvalidOperationException("Expresión RPN inválida.");

                    var b = stack.Pop();
                    var a = stack.Pop();

                    stack.Push(token switch
                    {
                        "+" => a + b,
                        "-" => a - b,
                        "*" => a * b,
                        "/" => b == 0 ? throw new DivideByZeroException() : a / b,
                        _ => throw new InvalidOperationException($"Operador desconocido: {token}")
                    });
                }
            }

            if (stack.Count != 1)
                throw new InvalidOperationException("Expresión RPN inválida.");

            return stack.Pop();
        }

        public bool ValidateExpression(string expression)
        {
            return !string.IsNullOrWhiteSpace(expression) && expression.Split(' ').Length > 2;
        }
    }
}