using Calculator.Services.Interfaces;
using Calculator.Database;
using Calculator.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using calculadora.Constants;

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

        [HttpPost]
        public IActionResult Post([FromBody] string expression)
        {
            try
            {
                if (!_service.ValidateExpression(expression))
                {
                    return StatusCode(HttpStatusCode.BAD_REQUEST, new
                    {
                        StatusCode = HttpStatusCode.BAD_REQUEST,
                        Status = false,
                        Message = "La expresión RPN no es válida.",
                        Data = new object ()
                    });
                }

                var result = _service.EvaluateRPN(expression);

                var operation = new CalculatorEntity
                {
                    Expression = expression,
                    Result = result,
                    CreatedAt = DateTime.UtcNow
                };

                _dbContext.Calculations.Add(operation);
                _dbContext.SaveChanges();

                return StatusCode(HttpStatusCode.Ok, new
                {
                    StatusCode = HttpStatusCode.Ok,
                    Status = true,
                    Message = "Operación realizada correctamente.",
                    Data = new { Expression = expression, Result = result }
                });
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.INTERNAL_SERVER_ERROR, new
                {
                    StatusCode = HttpStatusCode.INTERNAL_SERVER_ERROR,
                    Status = false,
                    Message = "Ocurrió un error al procesar la operación.",
                    Data = new { Detail = ex.Message }
                });
            }
        }

        [HttpGet("history")]
        public IActionResult GetHistory()
        {
            try
            {
                var operations = _dbContext.Calculations.ToList();

                return StatusCode(HttpStatusCode.Ok, new
                {
                    StatusCode = HttpStatusCode.Ok,
                    Status = true,
                    Message = "Historial obtenido correctamente.",
                    Data = operations
                });
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.INTERNAL_SERVER_ERROR, new
                {
                    StatusCode = HttpStatusCode.INTERNAL_SERVER_ERROR,
                    Status = false,
                    Message = "Ocurrió un error al recuperar el historial.",
                    Data = new { Detail = ex.Message }
                });
            }
        }

        [HttpGet("history/{id}")]
        public IActionResult GetOperationById(int id)
        {
            try
            {
                var operation = _dbContext.Calculations.FirstOrDefault(o => o.Id == id);

                if (operation == null)
                {
                    return StatusCode(HttpStatusCode.NOT_FOUND, new
                    {
                        StatusCode = HttpStatusCode.NOT_FOUND,
                        Status = false,
                        Message = $"No se encontró la operación con ID {id}.",
                        Data = new object()
                    });
                }

                return StatusCode(HttpStatusCode.Ok, new
                {
                    StatusCode = HttpStatusCode.Ok,
                    Status = true,
                    Message = "Datos obtenidos correctamente.",
                    Data = operation
                });
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.INTERNAL_SERVER_ERROR, new
                {
                    StatusCode = HttpStatusCode.INTERNAL_SERVER_ERROR,
                    Status = false,
                    Message = "Ocurrió un error al recuperar la operación.",
                    Data = new { Detail = ex.Message }
                });
            }
        }
    }
}