using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxCalculatorClient.Models.Interfaces
{
    public interface ICalculatorHandler
    {
        public void Calculate(double AnnualIncome, ref double TaxPayable);
    }
}
