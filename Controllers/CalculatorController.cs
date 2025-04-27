using Calculator.Services.Interfaces;
using Calculator.Database;
using Calculator.Database.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    [ApiController]
    [Route("api/calculator")]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _service;
        private readonly CalculatorDbContext _dbContext;

        public CalculatorController(ICalculatorService service, CalculatorDbContext dbContext)
        {
            _service = service;
            _dbContext = dbContext;
        }

        // Endpoint POST: Calcula el resultado de una expresión RPN y guarda la operación.
        [HttpPost]
        public IActionResult Post([FromBody] string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                return BadRequest(new { Error = "La expresión RPN no puede estar vacía." });
            }

            try
            {
                var result = _service.EvaluateRPN(expression);
                var operation = new CalculatorEntity
                {
                    Expression = expression,
                    Result = result,
                    CreatedAt = DateTime.UtcNow
                };

                _dbContext.Calculations.Add(operation);
                _dbContext.SaveChanges();

                return Ok(new { Expression = expression, Result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        // Endpoint GET: Recupera el historial completo de operaciones.
        [HttpGet("history")]
        public IActionResult GetHistory()
        {
            try
            {
                var operations = _dbContext.Calculations.ToList();
                return Ok(operations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "Ocurrió un error al recuperar el historial.", Detail = ex.Message });
            }
        }

        // Endpoint GET: Recupera los detalles de una operación específica usando su ID.
        [HttpGet("history/{id}")]
        public IActionResult GetOperationById(int id)
        {
            try
            {
                var operation = _dbContext.Calculations.FirstOrDefault(o => o.Id == id);

                if (operation == null)
                {
                    return NotFound(new { Error = $"No se encontró la operación con ID {id}." });
                }

                return Ok(operation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "Ocurrió un error al recuperar la operación.", Detail = ex.Message });
            }
        }
    }
}