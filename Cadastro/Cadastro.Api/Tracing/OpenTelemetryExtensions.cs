using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Cadastro.Api.Tracing
{
    public static class OpenTelemetryExtension
    {
        public static void AddOpenTelemetry(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddOpenTelemetryTracing(telemetry =>
            {

                var resourceBuilder = ResourceBuilder
                    .CreateDefault()
                    .AddService(builder.Configuration["Jaeger:ServiceName"]);

                telemetry
                    .SetResourceBuilder(resourceBuilder)
                    .AddAspNetCoreInstrumentation()
                    .SetSampler(new AlwaysOnSampler())
                    .AddJaegerExporter(jaegerOptions =>
                    {
                        jaegerOptions.AgentHost = builder.Configuration["Jaeger:AgentHost"];
                        jaegerOptions.AgentPort = Convert.ToInt32(builder.Configuration["Jaeger:AgentPort"]);
                    });
            });
        }
    }
}
