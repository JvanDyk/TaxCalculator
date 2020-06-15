using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxCalculatorApi.Models
{
    public class CalculatedModel
    {
        public int? Id { get; set; }
        public float AnnualIncome { get; set; }
        public string PostalCode { get; set; }
        public float Calculated { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
