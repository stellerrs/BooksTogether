using BooksTogether.Domain.Common;
using BooksTogether.Domain.Errors;

namespace BooksTogether.Domain.ValueObjects;

public class AuthorFullname : ValueObject
{
    private AuthorFullname(string fullname)
    {
        FullName = fullname;
    }
    
    public string FullName { get; }
    
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return FullName;
    }
    
    public static Result<AuthorFullname> Create(string fullname)
    {
        if (string.IsNullOrWhiteSpace(fullname))
            return Result<AuthorFullname>.Failure(AuthorFullnameErrors.EmptyFullname());
        
        return Result<AuthorFullname>.Success(new AuthorFullname(fullname));
    }
}