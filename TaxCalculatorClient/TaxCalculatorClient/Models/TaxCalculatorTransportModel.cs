using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxCalculatorClient.Models
{
    public class TaxCalculatorTransportModel
    {
        public int? Id { get; set; }

        public double AnnualIncome { get; set; } = 0.00;

        public string PostalCode { get; set; }

        public double Calculated { get; set; } = 0.00;
    }
}
