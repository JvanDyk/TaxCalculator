using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TaxCalculatorApi.Database;
using TaxCalculatorApi.Entities;
using TaxCalculatorApi.Models;
using TaxCalculatorApi.Models.Interfaces;
using System.Net;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace TaxCalculatorApi.Services
{
    public class TaxCalculatorService : ITaxCalculatorService
    {
        private readonly TaxDbContext _context;

        public TaxCalculatorService(TaxDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Create(CalculatedModel model)
        {
            try
            {
                _context.Taxes.Add(new CalculatedEntity()
                {
                    AnnualIncome = model.AnnualIncome,
                    PostalCode = model.PostalCode,
                    Calculated = model.Calculated,
                    UpdatedOn = DateTime.UtcNow
                }); ;
                await _context.SaveChangesAsync();
            }
            catch(Exception exception)
            {
                return new ContentResult
                {
                    Content = "Request Failed",
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
            return new ContentResult
            {
                Content = null,
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _context.Taxes.Remove(new CalculatedEntity()
                {
                    Id = id
                }); ;
                await _context.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                return new ContentResult
                {
                    Content = "Request Failed",
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
            return new ContentResult
            {
                Content = null,
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        public async Task<IActionResult> Read(int id)
        {
            try
            {
                var entity = _context.Taxes.FirstOrDefault(x => x.Id == id);
                if (entity == null)
                {
                    return new ContentResult
                    {
                        Content = null,
                        StatusCode = (int)HttpStatusCode.NotFound
                    };
                }
                var result = new CalculatedModel()
                {
                    AnnualIncome = entity.AnnualIncome,
                    PostalCode = entity.PostalCode,
                    Calculated = entity.Calculated,
                    UpdatedOn = entity.UpdatedOn,
                    Id = entity.Id
                };
                return new ContentResult
                {
                    Content = JsonConvert.SerializeObject(result),
                    StatusCode = (int)HttpStatusCode.OK
                    
                };
            }
            catch (Exception exception)
            {
                return new ContentResult
                {
                    Content = "Request Failed",
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
        }

        public async Task<IActionResult> ReadAll()
        {
            try
            {
                var entities = _context.Taxes.Select(tax => new CalculatedEntity
                {
                    Id = tax.Id,
                    AnnualIncome = tax.AnnualIncome,
                    PostalCode = tax.PostalCode,
                    Calculated = tax.Calculated,
                    UpdatedOn = tax.UpdatedOn
                }).ToList();

                if (entities == null || entities.Count == 0)
                {
                    return new ContentResult
                    {
                        Content = null,
                        StatusCode = (int)HttpStatusCode.NotFound
                    };
                }
                
                return new ContentResult
                {
                    Content = JsonConvert.SerializeObject(entities),
                    StatusCode = (int)HttpStatusCode.OK

                };
            }
            catch (Exception exception)
            {
                return new ContentResult
                {
                    Content = exception.Message,
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
        }

        public async Task<IActionResult> Update(CalculatedModel model)
        {
            try
            {
                _context.Taxes.Update(new CalculatedEntity()
                {
                    Id = model.Id.Value,
                    AnnualIncome = model.AnnualIncome,
                    PostalCode = model.PostalCode,
                    Calculated = model.Calculated,
                    UpdatedOn = DateTime.UtcNow
                });
                await _context.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                return new ContentResult
                {
                    Content = "Request Failed",
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
            return new ContentResult
            {
                Content = null,
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
