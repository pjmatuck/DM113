using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Message> Messages {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(
            "Server=localhost\\SQLEXPRESS;"
            + "User id=dm113;"
            + "Password=dm113;"
            + "Database=DM113;"
            + "Trusted_Connection=True;"
            + "encrypt=false");
    }
}