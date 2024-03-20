using System.Text.RegularExpressions;

namespace RoutingExample_RouteParameter_.CustomConstraints
{
    public class MonthsCustomConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            //check whether value exists
            if(!values.ContainsKey(routeKey)) //month
            {
                return false; //not a match
            }

            Regex regex = new Regex("^(apr|jul|oct|jan)$");
            string? monthValue = Convert.ToString(values[routeKey]);

            //checking if the monthValue matches Regex
            if (regex.IsMatch(monthValue))
            {
                return true; //it's a match
            }
            return false; //not a match
        }
    }
}
