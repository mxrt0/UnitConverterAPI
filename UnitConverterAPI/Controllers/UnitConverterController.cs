using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using UnitConverterAPI.Models;

namespace UnitConverterAPI.Controllers
{
    [ApiController]
    [Route("unitConverter")]
    public class UnitConverterController : ControllerBase
    {
        private readonly IConverterRepository _converterRepo;
        public UnitConverterController(IConverterRepository converterRepo)
        {
            _converterRepo = converterRepo;
        }

        [HttpGet("value={value}&from={fromUnit}&to={toUnit}")]
        public IActionResult Convert(double value, string fromUnit, string toUnit)
        {
            (double ResultValue, bool Success) result = 
                _converterRepo.Convert(value, fromUnit.ToLower(), toUnit.ToLower());

            if (result.Success)
            {
                return Ok(result.ResultValue);
            }
            else
            {
                return BadRequest("Conversion failed due to invalid data.");
            }

        }
  
    }
}
