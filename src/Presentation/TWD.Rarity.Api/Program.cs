using TWD.Rarity.Db.Base;
using TWD.Rarity.Db.Core.Repositories;

namespace TWD.Rarity.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        string connectionString = builder.Configuration.GetConnectionString("Postgres") 
            ?? throw new NullReferenceException("Connection string is empty! Check config.");
        builder.Services.AddTransient<IRepositoryManager, RepositoryManager>(provider => new RepositoryManager(connectionString));

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

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
