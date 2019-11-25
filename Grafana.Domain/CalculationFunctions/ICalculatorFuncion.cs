namespace Grafana.Domain.CalculationFunctions
{
    public interface ICalculatorFuncion
    {
        bool AppliesTo(int startValue);

        decimal Calculate(int startValue);
    }
}