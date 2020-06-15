using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxCalculatorClient.Models.Interfaces;

namespace TaxCalculatorClient.Models
{
    public class FlatValueTaxCalculatorHandler : ICalculatorHandler
    {
        public void Calculate(double AnnualIncome, ref double TaxPayable)
        {
            if (AnnualIncome < 200000)
            {
                TaxPayable = (AnnualIncome * 5 / 100);
            }
            else
            {
                TaxPayable = 10000;
            }
        }
    }
}
