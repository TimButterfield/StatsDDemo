using System;
using System.Collections.Generic;
using System.Linq;
using Grafana.Domain.CalculationFunctions;

namespace Grafana.Domain
{
    public class RandomCalculator
    {
        private readonly IEnumerable<ICalculatorFuncion> _functions;
        private readonly Random _random;
        private const int UpperLimit = 100;
        private const int LowerLimit = 1; 

        public RandomCalculator(IEnumerable<ICalculatorFuncion> functions)
        {
            _functions = functions;
            _random = new Random();
        }

        public decimal Calculate()
        {
            
            var startingValue = _random.Next(LowerLimit, UpperLimit);
            var functionToExecute = _functions.Single(x => x.AppliesTo(startingValue));
            return functionToExecute.Calculate(startingValue); 
        }
    }
}