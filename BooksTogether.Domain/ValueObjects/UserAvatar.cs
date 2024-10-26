using BooksTogether.Domain.Common;
using BooksTogether.Domain.Errors;

namespace BooksTogether.Domain.ValueObjects;

public class UserAvatar : ValueObject
{
    private UserAvatar(Uri imageUri, string format)
    {
        ImageUri = imageUri;
        Format = format;
    }

    public Uri ImageUri { get; }
    public string Format { get; }
    
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return ImageUri;
        yield return Format;
    }

    public static Result<UserAvatar> Create(Uri imageUri, string format)
    {
        if (string.IsNullOrWhiteSpace(format))
            return Result<UserAvatar>.Failure(UserImageErrors.EmptyFormat());
        
        return Result<UserAvatar>.Success(new UserAvatar(imageUri, format));
    }
}