using System;
using Grafana.Domain;
using Grafana.Domain.CalculationFunctions;
using JustEat.StatsD;
using NUnit.Framework;

namespace Grafana
{
    public class Consumer
    {
        private StatsDPublisher _publisher;
        private const string ServiceName = "Alto"; 
            
        [SetUp]
        public void Setup()
        {
            var statsDConfiguration = new StatsDConfiguration()
            {
                Host = "127.0.0.1",
                Port = 1234,
                Prefix = ServiceName,
                OnError = LogStatsError
            }; 
            
            _publisher = new StatsDPublisher(statsDConfiguration); 
        }

        private bool LogStatsError(Exception arg)
        {
            //log error here
            throw new NotImplementedException();
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
    }
}