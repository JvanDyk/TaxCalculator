using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxCalculatorClient.Configuration
{
    public class ServicesSettings
    {
        public Service Api { get; set; }
    }
    public class Service
    {
        public string ApiAddress { get; set; }
    }
}
