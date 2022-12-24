// Esta clase define un middleware para una aplicación web en C#.
public class TimeMiddleware
{
    // Almacena un delegado que representa un método que maneja una solicitud HTTP.
    // Este delegado se utilizará para permitir que el middleware siguiente en la cadena procese la solicitud.
    readonly RequestDelegate next;

    // Constructor que toma un parámetro de tipo RequestDelegate y lo almacena en la variable de instancia next.
    public TimeMiddleware(RequestDelegate nextRequest)
    {
        next = nextRequest;
    }

    // Método que toma un parámetro de tipo HttpContext y es marcado con el modificador async.
    // Este método representa la lógica del middleware.
    public async Task Invoke(HttpContext context)
    {
        // Llama al método next con el parámetro context para permitir que el middleware siguiente en la cadena procese la solicitud.
        await next(context);

        // Si el diccionario de consultas de la solicitud HTTP actual contiene una clave llamada "time",
        if (context.Request.Query.Any(p => p.Key == "time"))
        {
            // utilizando el método WriteAsync del objeto Response y el método ToShortTimeString para convertir la hora actual en una cadena en formato corto.
            await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
        }
    }
}


// Esta clase define un método de extensión que permite agregar el middleware TimeMiddleware a la cadena de middlewares de una aplicación web.
public static class TimeMiddlewareExtension
{
    // Método de extensión que toma un parámetro de tipo IApplicationBuilder y devuelve un objeto IApplicationBuilder modificado.
    public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
    {
        // Agrega el middleware TimeMiddleware a la cadena de middlewares de la aplicación utilizando el método UseMiddleware del objeto IApplicationBuilder.
        // Devuelve el objeto IApplicationBuilder modificado.
        return builder.UseMiddleware<TimeMiddleware>();
    }
}
