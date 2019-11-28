using System;
using System.Net.Http;

namespace StatsDExample.Domain.CalculationFunctions
{
    public class Calculator
    {
        private string Host = "http://localhost:5000";
        protected HttpClient Client;

        protected Calculator()
        {
            Client = new HttpClient
            {
                BaseAddress = new Uri(Host)
            };
        }  
    }
}