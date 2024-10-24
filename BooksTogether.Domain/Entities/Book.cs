using BooksTogether.Domain.Common;
using BooksTogether.Domain.ValueObjects;

namespace BooksTogether.Domain.Entities;

public class Book
{
    private readonly List<Author> _authors = [];
    private readonly List<Genre> _genres = [];
    
    public Book(
        Guid id,
        Title title,
        Annotation annotation,
        IReadOnlyList<Author> authors,
        ISBN? isbn,
        DateOnly? publishDate,
        IReadOnlyList<Genre> genres,
        bool isAgeLimited)
    {
        Id = id;
        Title = title;
        Annotation = annotation;
        Authors = authors;
        Isbn = isbn;
        PublishDate = publishDate;
        Genres = genres;
        IsAgeLimited = isAgeLimited;
    }

    public Guid Id { get; private set; }
    public Title Title { get; private set; }
    public Annotation Annotation { get; private set; }
    public IReadOnlyList<Author> Authors { get; private set; }
    public ISBN? Isbn { get; private set; }
    public DateOnly? PublishDate { get; private set; }
    public IReadOnlyList<Genre> Genres { get; private set; }
    public bool IsAgeLimited { get; private set; }

    public static Result<Book> Create(
        Title title,
        Annotation annotation,
        IEnumerable<Author> authors,
        ISBN isbn,
        DateOnly publishDate,
        IEnumerable<Genre> genres,
        bool isAgeLimited)
    {
        var book = new Book(
            Guid.NewGuid(),
            title,
            annotation,
            authors.ToList().AsReadOnly(),
            isbn,
            publishDate,
            genres.ToList().AsReadOnly(),
            isAgeLimited);

        return Result<Book>.Success(book);
    }
}