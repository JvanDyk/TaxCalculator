using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxCalculatorClient.Models.Interfaces
{
    public interface ITaxCalculatorTransport
    {
        public Task PersistAsync(TaxCalculator command);
    }
}
