using BooksTogether.Domain.Common;
using BooksTogether.Domain.ValueObjects;

namespace BooksTogether.Domain.Entities;

public class User
{
    private readonly List<Genre> _favoriteGenres = new();
    private readonly List<Book> _favoriteBooks = new();
    private readonly List<Book> _planToRead = new();
    private readonly List<Book> _booksRead = new();
    private readonly List<Book> _reading = new();
    private readonly List<User> _friends = new();

    private User(
        Guid id,
        Username username,
        Email? email,
        Phone? phone,
        Password password,
        Status? status,
        UserAvatar avatar,
        bool isPrivate)
    {
        Id = id;
        Username = username;
        Email = email;
        Password = password;
        PhoneNumber = phone;
        Status = status;
        Avatar = avatar;
        IsPrivate = isPrivate;
    }

    #region Properties

    public Guid Id { get; init; }
    public Username Username { get; private set; }
    public Email? Email { get; private set; }
    public Phone? PhoneNumber { get; private set; }
    public Password Password { get; private set; }
    public IReadOnlyList<Genre> FavoriteGenres => _favoriteGenres.AsReadOnly();
    public IReadOnlyList<Book> FavoriteBooks => _favoriteBooks.AsReadOnly();
    public IReadOnlyList<Book> PlanToRead => _planToRead.AsReadOnly();
    public IReadOnlyList<Book> BooksRead => _booksRead.AsReadOnly();
    public IReadOnlyList<Book> Reading => _reading.AsReadOnly();
    public IReadOnlyList<User> Friends => _friends.AsReadOnly();
    public Status? Status { get; private set; }
    public UserAvatar Avatar { get; private set; }
    public bool IsPrivate { get; private set; }

    #endregion

    public static Result<User> Create(
        Username username,
        Email? email,
        Phone? phone,
        Password password,
        Status? status,
        UserAvatar avatar,
        bool isPrivate)
    {
        var user = new User(
            Guid.NewGuid(),
            username,
            email,
            phone,
            password,
            status,
            avatar,
            isPrivate);
        
        return Result<User>.Success(user);
    }
}