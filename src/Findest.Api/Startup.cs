using Findest.Core;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.EntityFrameworkCore;
using Findest.Core.Repositories;

namespace Findest.Api;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = _configuration.GetConnectionString("Postgres")!;

        services
            .AddHttpContextAccessor()
            .AddRouting(options => options.LowercaseUrls = true)
            .AddMvcCore()
            .AddApiExplorer()
            .AddDataAnnotations();

        services
        .AddDbContext<EmployeesContext>(opt => opt.UseNpgsql(connectionString))
        .AddEndpointsApiExplorer()
        .AddSwaggerGen()
        .AddScoped(typeof(IPersonRepository), typeof(PersonRepository))
        .AddControllers();

        services.AddHealthChecks().AddNpgSql(connectionString);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
           {
               endpoints.MapControllers();
               endpoints.MapHealthChecks("/health", new HealthCheckOptions
               {
                   ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
               });
           });

        app.UseSwagger();
        app.UseSwaggerUI(c =>
       {
           c.SwaggerEndpoint("/swagger/v1/swagger.json", "Simple Api V1");
           c.DocExpansion(DocExpansion.None);
       });
    }
}


