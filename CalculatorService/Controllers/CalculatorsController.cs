using System;
using System.Threading;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorsController : ControllerBase
    {
        private Random _random;

        public CalculatorsController()
        {
            _random = new Random();
        }
        
        [HttpGet]
        [Route("square")]
        public IActionResult GetSquare (int value)
        {
            var result = value * value;
            Thread.Sleep(GetSleepWait());

            if (result > 100)
            {
                return BadRequest("Error");
            }

            return Ok(result);
        }

       
        [HttpGet]
        [Route("squareroot")]
        public IActionResult GetSquareRoot(int value)
        {
            Thread.Sleep(GetSleepWait());
            var result = Math.Sqrt(value);
            
            if (result > 6)
            {
                return BadRequest("Error");
            }
            
            return Ok(result);
        }
        
        
        
        
        
        
        private int GetSleepWait()
        {
            return _random.Next(10, 1000);
        }

    }
}