using BooksTogether.Application.Interfaces;
using BooksTogether.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BooksTogether.Persistence.Data.Contexts;

public class BooksDbContext(DbContextOptions<BooksDbContext> options) 
    : DbContext(options), IBooksDbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BooksDbContext).Assembly);
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Author> Authors { get; set; }
}