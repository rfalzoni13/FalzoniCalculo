using FalzoniCalculo.DI;
using FalzoniCalculo.Models.Classes;
using FalzoniCalculo.Service.Classes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FalzoniCalculo.Api.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class CalcController : ApiController
    {
        private readonly CalcService _calcService;

        public CalcController()
        {
            _calcService = DependencyService.ServiceProvider.GetService<CalcService>();
        }

        /// <summary>
        /// Calcular Valores
        /// </summary>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <param name="entry"></param>
        /// <remarks>Retorna o valor líquido e o valor bruto</remarks>
        /// <returns></returns>
        // POST: Calc/CalculateCurrency
        [HttpPost]
        public HttpResponseMessage CalculateCurrency(CurrencyEntryModel entry)
        {
            try
            {
                CurrencyReturnModel returnModel = _calcService.CalculateCurrency(entry);

                return Request.CreateResponse(System.Net.HttpStatusCode.OK, returnModel);
            }
            catch (ApplicationException ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
