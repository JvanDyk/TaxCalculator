using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using TaxCalculatorClient.Models.Interfaces;

namespace TaxCalculatorClient.Models
{
    public class TaxCalculator
    {
        public int? Id { get; set; }

        [Display(Name = "Annual Income")]
        [UIHint("Currency")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C0}")]
        public string AnnualIncome { get; set; } = "R0.00";

        [Required]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [UIHint("Currency")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C0}")]
        public double TaxPayable { get; set; } = 0.00;

        private ICalculatorHandler CalculatorHandler;

        public TaxCalculator()
        {
        }

        public void Calculate()
        {
            double tax = 00.00;
            double annualIncome;
            string currency = "";
            char[] currencySymbol = new char[] { 'R' };

            currency = AnnualIncome.Trim(currencySymbol);
            annualIncome = Double.Parse(currency, NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, new CultureInfo("en-US"));

            switch (PostalCode)
            {
                case "7441":
                    CalculatorHandler = new ProgressiveTaxCalculatorHandler();
                    CalculatorHandler.Calculate(annualIncome, ref tax);
                    break;
                case "A100":
                    CalculatorHandler = new FlatValueTaxCalculatorHandler();
                    CalculatorHandler.Calculate(annualIncome, ref tax);
                    break;
                case "7000":
                    CalculatorHandler = new FlatRateTaxCalculatorHandler();
                    CalculatorHandler.Calculate(annualIncome, ref tax);
                    break;
                case "1000":
                    CalculatorHandler = new ProgressiveTaxCalculatorHandler();
                    CalculatorHandler.Calculate(annualIncome, ref tax);
                    break;
            }

            TaxPayable = Math.Round(tax, 2);
        }
    }
}
