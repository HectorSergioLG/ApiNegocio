using ApiNegocio;
using ApiNegocio.Extensions;
using ApiNegocio.Middleware;
using Aplication;
using Infrastructure;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

builder.Services.AddPrecentation()
    .AddInfrastructure(builder.Configuration)
    .AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.ApplyMigrateDatabase();
    
    app.MapOpenApi(pattern: "/scalar/v1/openapi.json");
    app.MapScalarApiReference(
        endpointPrefix: "/scalar/v1",
        configureOptions: options =>
        {
            options.OpenApiRoutePattern = "/scalar/v1/openapi.json";
        });
    app.MapGet("/", (HttpContext context) => context.Response.Redirect("/scalar/v1", permanent: false));


}
app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalExcepctionHandlingMiddleware>();

app.MapControllers();

app.Run();
