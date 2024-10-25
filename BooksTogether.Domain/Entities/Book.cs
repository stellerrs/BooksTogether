using BooksTogether.Domain.Common;
using BooksTogether.Domain.ValueObjects;

namespace BooksTogether.Domain.Entities;

public class Book
{
    private readonly List<Author> _authors = new();
    private readonly List<Genre> _genres = new();
    
    public Book(
        Guid id,
        Title title,
        Annotation annotation,
        Price price,
        DateOnly? publishDate,
        bool isAgeLimited)
    {
        Id = id;
        Title = title;
        Annotation = annotation;
        Price = price;
        PublishDate = publishDate;
        IsAgeLimited = isAgeLimited;
    }

    public Guid Id { get; private set; }
    public Title Title { get; private set; }
    public Annotation Annotation { get; private set; }
    public IReadOnlyList<Author> Authors => _authors;
    public Price Price { get; private set; }
    public DateOnly? PublishDate { get; private set; }
    public IReadOnlyList<Genre> Genres => _genres;
    public bool IsAgeLimited { get; private set; }

    public static Result<Book> Create(
        Title title,
        Annotation annotation,
        Price price,
        DateOnly publishDate,
        bool isAgeLimited)
    {
        var book = new Book(
            Guid.NewGuid(),
            title,
            annotation,
            price,
            publishDate,
            isAgeLimited);

        return Result<Book>.Success(book);
    }
}