using System;

namespace Grafana.Domain.CalculationFunctions
{
    public class SquareRootCalculator : ICalculatorFuncion
    {
        public bool AppliesTo(int startValue)
        {
            return startValue % 2 != 0; 
        }

        public decimal Calculate(int startValue)
        {
            return (decimal)Math.Sqrt(startValue); 
        }
    }
}