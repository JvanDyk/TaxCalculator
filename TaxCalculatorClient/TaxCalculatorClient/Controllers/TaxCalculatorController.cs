using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaxCalculatorClient.Models;
using TaxCalculatorClient.Models.Interfaces;

namespace TaxCalculatorClient.Controllers
{
    public class TaxCalculatorController : Controller
    {
        private readonly ILogger<TaxCalculatorController> _logger;
        private readonly ITaxCalculatorTransport _taxCalculatorTransporter;
        private TaxCalculator _taxCalculator;

        public TaxCalculatorController(ILogger<TaxCalculatorController> logger, ITaxCalculatorTransport taxCalculatorTransporter)
        {
            _logger = logger;
            _taxCalculator = new TaxCalculator();
            _taxCalculatorTransporter = taxCalculatorTransporter;
        }

        public IActionResult Index()
        {
            return View(_taxCalculator);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Calculate(TaxCalculator taxCalculator)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", taxCalculator);
            }
            taxCalculator.Calculate();
            //ViewBag.TaxPayable = taxCalculator.TaxPayable;

            await _taxCalculatorTransporter.PersistAsync(taxCalculator);

            return View("Index", taxCalculator);
        }
    }
}
