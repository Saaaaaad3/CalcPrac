using Microsoft.EntityFrameworkCore;
using Practice.Calculator.Data.Models;

namespace Practice.Calculator.Data
{
    public class CalculatorContext : DbContext
    {
        public CalculatorContext(DbContextOptions<CalculatorContext> options) : base(options)
        {
        }

        public DbSet<CalculatorHistory> CalculatorHistory { get; set; }
        public DbSet<CalculatorSetting> CalculatorSetting { get; set; }
        public DbSet<PostalCode> PostalCode { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


       
    }
}
