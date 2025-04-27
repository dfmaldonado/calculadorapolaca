using Calculator.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Calculator.Database
{
    public class CalculatorDbContext : DbContext
    {
        public DbSet<CalculatorEntity> Calculations { get; set; } // Tabla de operaciones.

        public CalculatorDbContext(DbContextOptions<CalculatorDbContext> options) : base(options)
        {
        }
    }
}