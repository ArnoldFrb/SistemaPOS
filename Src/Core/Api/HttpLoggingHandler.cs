using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace SistemaPOS.Src.Core.Api
{
    public class HttpLoggingHandler(ILogger<HttpLoggingHandler> logger) : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Log the request details (e.g., URL, headers, etc.) here
            // You can use a logging library like Serilog or Console.WriteLine

            var response = await base.SendAsync(request, cancellationToken);

            // Log the response details (e.g., status code, content, etc.) here
            Debug.WriteLine(response);
            logger.LogInformation("{response.Content}", response.Content);

            return response;
        }
    }
}
