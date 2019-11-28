using System;
using System.Threading;
using StatsDExample.Domain;
using NUnit.Framework;
using Serilog;
using Serilog.Core;
using StatsdClient;
using StatsDExample.Domain.CalculationFunctions;

namespace Grafana
{
    public class Consumer
    {
        private static ILogger _logger;
        private const string ServiceName = "Alto"; 
            
        [SetUp]
        public void Setup()
        {
            //https://docs.datadoghq.com/developers/dogstatsd/?tab=net
            ConfigureStatsD();
            ConfigureLogging(); 
        }

       


        [Test]
        public void InvokeCalculator()
        {
            var calculator = new RandomCalculator(new ICalculatorFunction[]
            {
                new SquareCalculator(), 
                new SquareRootCalculator()
            }, _logger);

            for (var counter = 0; counter < 20; counter++)
            {
                using (DogStatsd.StartTimer("calculator.calculate"))
                {
                    var result = calculator.Calculate();
                    Thread.Sleep(TimeSpan.FromSeconds(3));
                }
            }
        }
        
        
        
        
        
        
        private static void ConfigureStatsD()
        {
            var statsdConfig = new StatsdConfig
            {
                StatsdServerName = "127.0.0.1",
                StatsdPort = 8125,
                Prefix = ServiceName
            };

            DogStatsd.Configure(statsdConfig);
        }
        
        private static void ConfigureLogging()
        {
            _logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("log.txt")
                .CreateLogger();
        }
    }
}