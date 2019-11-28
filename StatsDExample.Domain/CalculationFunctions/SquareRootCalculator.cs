using System;
using System.Threading.Tasks;
using StatsdClient;

namespace StatsDExample.Domain.CalculationFunctions
{
    public class SquareRootCalculator : Calculator, ICalculatorFunction
    {
        public bool AppliesTo(int startValue)
        {
            return startValue % 2 != 0; 
        }
       
        public async Task<decimal> Calculate(int startValue)
        {
            var response = await Client.GetAsync($"/calculators/squareroot?value={startValue}");
            
            DogStatsd.Increment($"{nameof(SquareRootCalculator)}.{nameof(Calculate).ToLower()}.{response.StatusCode}"); 
            
            return Convert.ToDecimal(response.Content.ReadAsStringAsync());
        }
    }
}