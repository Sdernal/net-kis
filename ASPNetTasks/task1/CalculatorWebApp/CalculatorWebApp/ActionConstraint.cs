using System.Collections;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace CalculatorWebApp
{
    public class ActionConstraint : IRouteConstraint
    {
        readonly string[] _actions = { "start", "add", "subtract", "multiply", "divide" };
        public bool Match(HttpContext httpContext, IRouter route, string routeKey,
            RouteValueDictionary values, RouteDirection routeDirection)
        {
            return _actions.Contains(values[routeKey]?.ToString());
        }
    }
}