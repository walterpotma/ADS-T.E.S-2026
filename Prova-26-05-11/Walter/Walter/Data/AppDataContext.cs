using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Walter.Models;

namespace Walter.Data;
public class AppDataContext : DbContext
{
    public DbSet<Livro> Livros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=walter.db");
    }
}