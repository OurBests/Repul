using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using web.Common;

namespace web.Middlewares
{
    public class ExceptionCustomHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionCustomHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (ManualException ex)
            {
                httpContext.Response.StatusCode = 800;
                httpContext.Response.ContentType = "application/json;charset=utf-8";
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new { Message = ex.Message }),Encoding.UTF8);
            }
        }
    }

}
