using System;

namespace Calculator.Database.Entities
{
    // Clase: CalculatorEntity
    public class CalculatorEntity
    {
        public int Id { get; set; } // Clave primaria
        public required string Expression { get; set; } // Expresión en notación polaca inversa (RPN)
        public double Result { get; set; } // Resultado de la operación
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Fecha y hora de creación automática
    }
}
