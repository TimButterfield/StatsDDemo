using System;
using JustEat.StatsD;

namespace Grafana.Domain.CalculationFunctions
{
    public class SquareRootCalculator : ICalculatorFuncion
    {
        private readonly IStatsDPublisher _statsPublisher;

        public SquareRootCalculator(IStatsDPublisher statsPublisher)
        {
            _statsPublisher = statsPublisher;
        }
        
        public bool AppliesTo(int startValue)
        {
            return startValue % 2 != 0; 
        }

        public decimal Calculate(int startValue)
        {
            _statsPublisher.Increment( $"{nameof(SquareRootCalculator).ToLower()}.count");
            return (decimal)Math.Sqrt(startValue); 
        }
    }
}