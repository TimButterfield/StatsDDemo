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
            var sleepWait = _random.Next(10, 1000); 
            Thread.Sleep(sleepWait);
            return Ok(value * value);
        }
        
        [HttpGet]
        [Route("squareroot")]
        public IActionResult GetSquareRoot(int value)
        {
            var sleepWait = _random.Next(10, 1000); 
            Thread.Sleep(sleepWait);
            return Ok((decimal)Math.Sqrt(value));
        }
    }
}