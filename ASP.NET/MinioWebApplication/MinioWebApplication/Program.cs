
using Minio;

namespace MinioWebApplication;

public class Program
{
    private const string Endpoint = "127.0.0.1:9000";
    private const string AccessKey = "7WoqwCaB7hyTkIlIWrfT";
    private const string SecretKey = "8GuRfIyisj9DEsgbh4h3hysU8eU7XsMzaICBXVzt";
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddMinio(client =>
        {
            client
                .WithEndpoint(Endpoint)
                .WithCredentials(AccessKey, SecretKey)
                .WithSSL(false)
                .Build();
        });
        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
