using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CalculatorWebApp
{
    public class ReadCookiesMiddleware
    {
        private readonly RequestDelegate _next;

        public ReadCookiesMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, CalculatorService calculatorService)
        {
            context.Items["result"] = calculatorService.GetCurrentResult(context);
            
            await _next.Invoke(context);
        }
    }
}