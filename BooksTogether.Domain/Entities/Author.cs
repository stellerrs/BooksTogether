using BooksTogether.Domain.Common;
using BooksTogether.Domain.ValueObjects;

namespace BooksTogether.Domain.Entities;

public class Author
{
    private readonly List<Book> _books = new();
    
    private Author(Guid id, AuthorFullname fullname)
    {
        Id = id;
        Fullname = fullname;
    }
    
    public Guid Id { get; private set; }
    public AuthorFullname Fullname { get; private set; }
    public IReadOnlyList<Book> Books => _books;

    public Result<Author> Create(AuthorFullname fullname)
    {
        var author = new Author(
            Guid.NewGuid(),
            fullname);
        
        return Result<Author>.Success(author);
    }
}