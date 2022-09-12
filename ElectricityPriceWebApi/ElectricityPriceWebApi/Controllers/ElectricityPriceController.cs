using ElectricityPriceWebApi.Models;
using ElectricityPriceWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElectricityPriceWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ElectricityPriceController : ControllerBase
    {
        private readonly IElectricityPriceService electricityPriceService;

        public ElectricityPriceController(IElectricityPriceService electricityPriceService)
        {
            this.electricityPriceService = electricityPriceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ElectricityPrice>>> GetElectricityPrices()
        {
            return new JsonResult(await electricityPriceService.GetAll());
        }
    }
}