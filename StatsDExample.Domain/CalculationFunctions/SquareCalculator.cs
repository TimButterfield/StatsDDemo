using System;
using System.Threading.Tasks;
using StatsdClient;

namespace StatsDExample.Domain.CalculationFunctions
{
    public class SquareCalculator : Calculator, ICalculatorFunction
    {
        public bool AppliesTo(int startValue)
        {
            return startValue % 2 == 0; 
        }

        public async Task<decimal> Calculate(int startValue)
        {
            var response = await Client.GetAsync($"/calculators/square?value={startValue}");

            DogStatsd.Increment($"{nameof(SquareCalculator)}.{nameof(Calculate).ToLower()}.{response.StatusCode}.count"); 
            
            return Convert.ToDecimal(response.Content.ReadAsStringAsync());
        }
    }
}