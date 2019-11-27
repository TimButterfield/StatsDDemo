using System;
using Grafana.Domain;
using Grafana.Domain.CalculationFunctions;
using JustEat.StatsD;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Grafana
{
    public class Consumer
    {
        private StatsDPublisher _publisher;
        private ILogger<Consumer> _logger;
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
            
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("LoggingConsoleApp.Program", LogLevel.Debug); 
            });

            _logger = loggerFactory.CreateLogger<Consumer>();
        }

        private bool LogStatsError(Exception exception)
        {
            //log error here
            _logger.LogError(exception, "Error recording stats");
            return true;
        }

        [Test]
        public void InvokeCalculator()
        { 
            
            var calculator = new RandomCalculator(new ICalculatorFuncion[]
            {
                new SquareCalculator(_publisher), 
                new SquareRootCalculator(_publisher)
            });
            
            //Should we record or stat anything here? 
            using (_publisher.StartTimer($"{nameof(RandomCalculator).ToLower()}.calculate"))
            {
                var result = calculator.Calculate(); 
                _logger.LogInformation($"{nameof(RandomCalculator)} returned {result}");
            }
        }
    }
}