using Practice.Calculator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Calculator.Services.Abstractions
{
    public interface ICalculator
    {
        Task<decimal> CalculateAsync(decimal income);
    }
}
