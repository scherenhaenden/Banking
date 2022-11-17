namespace BankingClientBackend.Services.Middlewares.JWT;

public class ReadAndResponseJWT
{
    private readonly RequestDelegate _next;

    public ReadAndResponseJWT(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            //if has request header, do nothing
            /*if (httpContext.Request.Headers.TryGetValue("Authorization", out var authHeader) && authHeader.Any() &&
                authHeader[0].StartsWith("Bearer", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }*/

            /*var endpoint = httpContext.GetEndpoint();
            var attribute = endpoint.Metadata.OfType<JwtParameterAttribute>().FirstOrDefault();
            if (attribute != null && httpContext.Request.Query.TryGetValue(attribute.Parameter, out var param))
            {
                var token = param.FirstOrDefault();
                if (!string.IsNullOrWhiteSpace(token))
                {
                    httpContext.Request.Headers.Add("Authorization", $"Bearer {token}");
                }
            }*/
        }
        finally
        {
            // Call the next middleware delegate in the pipeline 
            await _next.Invoke(httpContext);
        }
    }
}