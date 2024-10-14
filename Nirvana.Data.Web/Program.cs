
using Nirvana.Data.Application;
using Nirvana.Data.Infrastructure;
using Nirvana.Data.Presentation;

namespace Nirvana.Data.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services
            .AddApplication()
            .AddInfrastructure()
            .AddPresentation();

        builder.Services.AddControllers()
            .AddApplicationPart(typeof(PresentationServiceCollectionExtensions).Assembly);

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddHealthChecks();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapHealthChecks("health");
        app.MapControllers();

        app.Run();
    }
}
