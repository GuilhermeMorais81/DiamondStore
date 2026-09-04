using DiamondStore.Models;
using Microsoft.EntityFrameworkCore;

namespace DiamondStore.Data;

public class DataContext : DbContext
{
    public DbSet<Game> Games { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared;Mode=ReadWrite");
}