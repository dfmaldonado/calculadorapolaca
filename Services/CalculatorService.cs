using Calculator.Services.Interfaces;

namespace Calculator.Services
{
    public class CalculatorService : ICalculatorService
    {
        public double EvaluateRPN(string expression)
        {
            var stack = new Stack<double>();
            var tokens = expression.Split(' ');

            foreach (var token in tokens)
            {
                if (double.TryParse(token, out var number))
                {
                    stack.Push(number);
                }
                else
                {
                    var b = stack.Pop();
                    var a = stack.Pop();
                    stack.Push(token switch
                    {
                        "+" => a + b,
                        "-" => a - b,
                        "*" => a * b,
                        "/" => a / b,
                        _ => throw new ArgumentException("Operador no válido")
                    });
                }
            }

            return stack.Pop();
        }
    }
}