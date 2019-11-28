using System.Threading.Tasks;

namespace StatsDExample.Domain.CalculationFunctions
{
    public interface ICalculatorFunction
    {
        bool AppliesTo(int startValue);

        Task<decimal> Calculate(int startValue);
    }
}