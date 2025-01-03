﻿using BooksTogether.Domain.Common;
using BooksTogether.Domain.ValueObjects;

namespace BooksTogether.Domain.Entities;

public class Book
{
    private readonly List<Author> _authors = new();
    private readonly List<Genre> _genres = new();
    
    private Book(
        Guid id,
        Title title,
        Annotation annotation,
        Price price,
        PublishDate? publishDate,
        bool isAgeLimited,
        BookCover cover,
        Rating rating)
    {
        Id = id;
        Title = title;
        Annotation = annotation;
        Price = price;
        PublishDate = publishDate;
        IsAgeLimited = isAgeLimited;
        Cover = cover;
        Rating = rating;
    }

    public Guid Id { get; init; }
    public Title Title { get; private set; }
    public Annotation Annotation { get; private set; }
    public Price Price { get; private set; }
    public PublishDate? PublishDate { get; private set; }
    public bool IsAgeLimited { get; private set; }
    public Rating Rating { get; private set; }
    public BookCover Cover { get; private set; }
    public IReadOnlyList<Author> Authors => _authors.AsReadOnly();
    public IReadOnlyList<Genre> Genres => _genres.AsReadOnly();

    public static Result<Book> Create(
        Title title,
        Annotation annotation,
        Price price,
        PublishDate? publishDate,
        bool isAgeLimited,
        BookCover cover,
        Rating rating)
    {
        var book = new Book(
            Guid.NewGuid(),
            title,
            annotation,
            price,
            publishDate,
            isAgeLimited,
            cover,
            rating);

        return Result<Book>.Success(book);
    }
}