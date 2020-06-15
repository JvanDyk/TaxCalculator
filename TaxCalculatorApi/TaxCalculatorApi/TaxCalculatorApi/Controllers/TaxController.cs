using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TaxCalculatorApi.Database;
using TaxCalculatorApi.Entities;
using TaxCalculatorApi.Models;
using TaxCalculatorApi.Models.Interfaces;

namespace TaxCalculatorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        private readonly ITaxCalculatorService _taxCalculatorService;
        

        public TaxController(ITaxCalculatorService taxCalculatorService) 
        {
            _taxCalculatorService = taxCalculatorService;
        }

        [HttpPost]
        [SwaggerOperation("CREATE")]
        [Route("CREATE")]
        public async Task<IActionResult> Create([FromBody] CalculatedModel request)
        {
            return await _taxCalculatorService.Create(request);
        }

        [HttpGet]
        [Route("READ")]
        public async Task<IActionResult> Read([FromBody] CalculatedModel request)
        {
            return await _taxCalculatorService.Read(request.Id.Value);
        }

        [HttpPost]
        [Route("UPDATE")]
        public async Task<IActionResult> Update([FromBody] CalculatedModel request)
        {
            return await _taxCalculatorService.Update(request);
        }

        [HttpDelete]
        [Route("DELETE")]
        public async Task<IActionResult> Delete([FromBody] CalculatedModel request)
        { 
            return await _taxCalculatorService.Delete(request.Id.Value);
        }

      
    }
}
