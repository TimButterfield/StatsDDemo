using JustEat.StatsD;

namespace Grafana.Domain.CalculationFunctions
{
    public class SquareCalculator : ICalculatorFuncion
    {
        private readonly IStatsDPublisher _statsPublisher;

        public SquareCalculator(IStatsDPublisher statsPublisher)
        {
            _statsPublisher = statsPublisher;
        }
        
        public bool AppliesTo(int startValue)
        {
            return startValue % 2 == 0; 
        }

        public decimal Calculate(int startValue)
        {
            _statsPublisher.Increment( $"{nameof(SquareCalculator).ToLower()}.count");
            return startValue * startValue; 
        }
    }
}