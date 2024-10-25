using BooksTogether.Domain.Common;
using BooksTogether.Domain.ValueObjects;

namespace BooksTogether.Domain.Entities;

public class Genre
{
    private readonly List<Book> _books = new();

    private Genre(Guid id, GenreName name)
    {
        Id = id;
        Name = name;
    }
    
    public Guid Id { get; private set; }
    public GenreName Name { get; private set; }
    public IReadOnlyList<Book> Books => _books;

    public static Result<Genre> Create(GenreName name)
    {
        var genre = new Genre(Guid.NewGuid(), name);
        
        return Result<Genre>.Success(genre);
    }
}