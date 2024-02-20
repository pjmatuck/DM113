
namespace WebAppDb;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<AppDbContext>();
        builder.Services.AddAuthorization();
        builder.Services.AddEndpointsApiExplorer();

        var app = builder.Build();

        app.MapGet("/", () => { return "Olá mundo!"; });

        app.MapPost("/", (Player player, AppDbContext db) => {
            db.Players.Add(player);
            Console.WriteLine($"Player: {player.Id}");
            db.SaveChanges();
            return Results.Created();
        });

        app.Run();
    }
}
