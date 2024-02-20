using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Player> Players {get; set;}
    public DbSet<Weapon> Weapons {get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(
            "Server=localhost\\SQLEXPRESS;"
            + "User id=dm113;"
            + "Password=dm113;"
            + "Database=WebAppDb;"
            + "Trusted_Connection=True;"
            + "encrypt=false");
    }
}