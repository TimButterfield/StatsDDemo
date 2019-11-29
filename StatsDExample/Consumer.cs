using NUnit.Framework;
using StatsdClient;
using StatsDExample.Domain;
using StatsDExample.Domain.CalculationFunctions;

namespace StatsDExample
{
    public class Consumer
    {
        private const string ServiceName = "ProductFoo"; 
            
        [SetUp]
        public void Setup()
        {
            ConfigureStatsD();
        }


        [Test]
        public void InvokeCalculator()
        {
            var calculator = new RandomCalculator(new ICalculatorFuncion[]
            {
                new SquareCalculator(), 
                new SquareRootCalculator()
            });
            
            //Should we record or stat anything here? 
            var result = calculator.Calculate(); 
        }
        
        private static void ConfigureStatsD()
        {
            var configuration = new StatsdConfig
            {
                StatsdServerName = "127.0.0.1",
                StatsdPort = 8125,
                Prefix = ServiceName
            };

            DogStatsd.Configure(configuration);
        }
    }
}
