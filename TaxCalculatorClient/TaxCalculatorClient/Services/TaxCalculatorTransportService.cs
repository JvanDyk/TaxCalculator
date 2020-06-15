using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TaxCalculatorClient.Configuration;
using TaxCalculatorClient.Models;
using TaxCalculatorClient.Models.Interfaces;

namespace TaxCalculatorClient.Services
{
    public class TaxCalculatorTransportService : ITaxCalculatorTransport
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ServicesSettings _servicesSettings;

        public TaxCalculatorTransportService(IHttpClientFactory httpClientFactory, IOptions<ServicesSettings> servicesSettings)
        {
            _httpClientFactory = httpClientFactory;
            _servicesSettings = servicesSettings.Value;
        }

        public async Task PersistAsync(TaxCalculator command)
        {
            char[] currencySymbol = new char[] { 'R' };
            const string ROUTE = "/api/Tax/CREATE";

            var transportModel = new TaxCalculatorTransportModel();

            transportModel.Id = command.Id;
            transportModel.PostalCode = command.PostalCode;
            transportModel.Calculated = command.TaxPayable;
            string currency = command.AnnualIncome.Trim(currencySymbol);
            transportModel.AnnualIncome = Double.Parse(currency, NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, new CultureInfo("en-US"));

            using var client = _httpClientFactory.CreateClient();
            try{
                using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, _servicesSettings.Api.ApiAddress + ROUTE))
                {
                    requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
                    var json = JsonConvert.SerializeObject(transportModel);
                    requestMessage.Content = new StringContent(json, Encoding.UTF8, "Application/json");
                    var response = await client.SendAsync(requestMessage);
                    var content = response.Content.ReadAsStringAsync().Result;
                }
            }
            catch(Exception exception)
            {
                // Log Error response
                // throw new Exception(exception.Message);
            }
         
        }
    }
}
