using ApiNegocio.Middleware;

namespace ApiNegocio
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPrecentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddOpenApi();
            services.AddEndpointsApiExplorer();
            services.AddTransient<GlobalExcepctionHandlingMiddleware>();

            return services;
        }
    }
}
