using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Classes6.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Request.EnableBuffering();

            if (context.Request != null)
            {
                string path = context.Request.Path;
                string method = context.Request.Method;
                string queryString = context.Request.QueryString.ToString();
                string bodyStr = "";

                using (StreamReader reader = new StreamReader(context.Request.Body,
                    Encoding.UTF8, true, 1024, true))
                {
                    bodyStr = await reader.ReadToEndAsync();
                    context.Request.Body.Position = 0;
                }

                StreamWriter writer = File.AppendText(@"requestsLog.txt");
                writer.WriteLine("\nLogging info: " + DateTime.Now);
                writer.WriteLine("Path: " + path);
                writer.WriteLine("Method: " + method);
                writer.WriteLine("Query string: " + queryString);
                writer.WriteLine("Body:\n" + bodyStr);
                writer.Close();

                await _next(context);
            }
        }
    }
}