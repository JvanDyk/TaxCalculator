using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace TaxCalculatorApi.Entities
{
    public class CalculatedEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public float AnnualIncome { get; set; }
        public string PostalCode { get; set; }
        public float Calculated { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
