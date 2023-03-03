using Microsoft.AspNetCore.Mvc.Filters;

namespace MyAspNetCoreApp.Web.Filters
{
    public class CustomResultFilter: ActionFilterAttribute
    {
        private readonly string _name;
        private readonly string _value;

        public CustomResultFilter(string name, string value)
        {
            _name = name;
            _value = value;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add(_name,_value);

            base.OnActionExecuting(context);
        }
    }
}
