using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxCalculatorClient.Models.Interfaces;

namespace TaxCalculatorClient.Models
{
    public class FlatRateTaxCalculatorHandler : ICalculatorHandler
    {
        public double FlatRate { get; set; } = 17.5;

        // Note: The assessment states that the calculation is based on their income 
        // and I'm going to assume it's talking about their annual income.
        public void Calculate(double AnnualIncome, ref double TaxPayable)
        {
            TaxPayable = (AnnualIncome * FlatRate / 100);
        }
    }
}
