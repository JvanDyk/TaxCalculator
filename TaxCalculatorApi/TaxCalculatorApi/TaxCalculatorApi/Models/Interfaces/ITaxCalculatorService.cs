using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxCalculatorApi.Models.Interfaces
{
    public interface ITaxCalculatorService
    {
        public Task<IActionResult> Create(CalculatedModel model);
        public Task<IActionResult> Read(int id);
        public Task<IActionResult> Update(CalculatedModel model);
        public Task<IActionResult> Delete(int id);
    }
}
