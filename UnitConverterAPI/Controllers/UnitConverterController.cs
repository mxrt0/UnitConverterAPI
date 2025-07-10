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

        [HttpGet("convert/value={valueToConvert}&from={fromUnit}&to={toUnit}")]
        public IActionResult Convert(double valueToConvert, string fromUnit, string toUnit)
        {
            try 
            {
                (double ResultValue, bool Success) result =
                _converterRepo.Convert(valueToConvert, fromUnit.ToLower(), toUnit.ToLower());

                if (result.Success)
                {
                    return Ok($"{result.ResultValue:f2}");
                }
                return BadRequest("Invalid conversion units.");
            }
            catch (Exception ex) 
            {
                return BadRequest($"Inversion failed: {ex.Message}");
            }
            
            

        }
  
    }
}
