using BooksTogether.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BooksTogether.Application.Interfaces;

public interface IBooksDbContext
{
    DbSet<Book> Books { get; set; }
    DbSet<Genre> Genres { get; set; }
    DbSet<Author> Authors { get; set; }
    DbSet<User> Users { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}