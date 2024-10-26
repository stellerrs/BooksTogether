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

    public User(Guid id, Username username, Email email, Password password, Status? status, UserAvatar avatar)
    {
        Id = id;
        Username = username;
        Email = email;
        Password = password;
        Status = status;
        Avatar = avatar;
    }

    public Guid Id { get; set; }
    public Username Username { get; private set; }
    public Email Email { get; private set; }
    public Password Password { get; private set; }
    public IReadOnlyList<Genre> FavoriteGenres => _favoriteGenres;
    public IReadOnlyList<Book> FavoriteBooks => _favoriteBooks;
    public IReadOnlyList<Book> PlanToRead => _planToRead;
    public IReadOnlyList<Book> BooksRead => _booksRead;
    public IReadOnlyList<Book> Reading => _reading;
    public IReadOnlyList<User> Friends => _friends;
    public Status? Status { get; private set; }
    public UserAvatar Avatar { get; private set; }

    public static Result<User> Create(
        Username username,
        Email email,
        Password password,
        Status? status,
        UserAvatar avatar)
    {
        var user = new User(Guid.NewGuid(), username, email, password, status, avatar);
        
        return Result<User>.Success(user);
    }
}