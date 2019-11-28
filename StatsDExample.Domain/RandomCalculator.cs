using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using StatsdClient;
using StatsDExample.Domain.CalculationFunctions;

namespace StatsDExample.Domain
{
    public class RandomCalculator
    {
        private readonly IEnumerable<ICalculatorFunction> _functions;
        private readonly ILogger _logger;
        private readonly Random _random;
        private const int UpperLimit = 100;
        private const int LowerLimit = 1; 

        public RandomCalculator(IEnumerable<ICalculatorFunction> functions, ILogger logger)
        {
            _functions = functions;
            _logger = logger;
            _random = new Random();
            
        }

        public async Task<decimal> Calculate()
        {
            var startingValue = 0;
            ICalculatorFunction functionToExecute = null; 
                
            try
            {
                startingValue = _random.Next(LowerLimit, UpperLimit);
                functionToExecute = _functions.Single(x => x.AppliesTo(startingValue));

                DogStatsd.Increment($"calculator.{functionToExecute.GetType().Name}.calculateUsingRemote.count");

                return await functionToExecute.Calculate(startingValue);
            }
            catch (Exception exception)
            {
                _logger.Error(exception, "Unable to perform calculation using {startingValue}, and {functionToExecute}", startingValue, functionToExecute);
                throw;
            }
        }
    }
}