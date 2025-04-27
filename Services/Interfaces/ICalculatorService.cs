namespace Calculator.Services.Interfaces
{
    public interface ICalculatorService
    {
        // Método para evaluar expresiones RPN.
        double EvaluateRPN(string expression);
        // Método para validar una expresión RPN.
        bool ValidateExpression(string expression);
    }
}