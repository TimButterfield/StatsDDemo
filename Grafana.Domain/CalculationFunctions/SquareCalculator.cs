namespace Grafana.Domain.CalculationFunctions
{
    public class SquareCalculator : ICalculatorFuncion
    {
        public bool AppliesTo(int startValue)
        {
            return startValue % 2 == 0; 
        }

        public decimal Calculate(int startValue)
        {
            return startValue * startValue; 
        }
    }
}