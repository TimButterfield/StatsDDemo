namespace StatsDExample.Domain.CalculationFunctions
{
    public interface ICalculatorFuncion
    {
        bool AppliesTo(int startValue);

        decimal Calculate(int startValue);
    }
}