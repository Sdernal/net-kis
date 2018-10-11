using Microsoft.AspNetCore.Http;

namespace CalculatorWebApp
{
    public class CalculatorService
    {
        public double GetCurrentResult(HttpContext context)
        {
            if (context.Request.Cookies.ContainsKey("result"))
            {
                return double.Parse(context.Request.Cookies["result"]);
            }
            return 0d;
        }
        
        public double Add(double a, double b) => a + b;
        
        public double Subtract(double a, double b) => a - b;
        
        public double Multiply(double a, double b) => a * b;
        
        public double Divide(double a, double b) => a / b;
    }
}