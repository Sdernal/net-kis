using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebApp
{
    public class Counting
    {
        public interface ICounter
        {
            int Value { get; }
        }

        public class RandomCounter : ICounter
        {
            static Random rnd = new Random();
            private int _value;
            public RandomCounter()
            {
                _value = rnd.Next(0, 1000000);
            }
            public int Value { get { return _value; } }
        }

        public class CounterService
        {
            protected internal ICounter Counter { get; }
            public CounterService(ICounter counter)
            {
                Counter = counter;
            }
        }

        public class CounterMiddleware
        {
            private readonly RequestDelegate _next;
            private int requestCounter = 0;
            public CounterMiddleware(RequestDelegate next)
            {
                _next = next;
            }

            public async Task Invoke(HttpContext httpContext, ICounter counter, CounterService counterService)
            {
                requestCounter++;
                await httpContext.Response.WriteAsync($"Request: {requestCounter}; Counter: {counter.Value}; Service: {counterService.Counter.Value}");
            }
        }
    }
}
