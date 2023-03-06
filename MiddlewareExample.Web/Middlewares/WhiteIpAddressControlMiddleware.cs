namespace MiddlewareExample.Web.Middlewares
{
    public class WhiteIpAddressControlMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public WhiteIpAddressControlMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke Aysnc(HttpContent context)
        {
            //IPV4 => 127.0.0.1 => localhost
            //       IP address     DNS name
            //IPV6 => ::1 => localhost
         }
    }
}
