using BooksTogether.Domain.Common;
using BooksTogether.Domain.Errors;

namespace BooksTogether.Domain.ValueObjects;

public class BookCover : ValueObject
{
    private BookCover(Uri fullSizeImageUrl, Uri thumbnailImageUrl, string format)
    {
        FullSizeImageUrl = fullSizeImageUrl;
        ThumbnailImageUrl = thumbnailImageUrl;
        Format = format;
    }

    public Uri FullSizeImageUrl { get; }
    public Uri ThumbnailImageUrl { get; }
    public string Format { get; }
    
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return FullSizeImageUrl;
        yield return ThumbnailImageUrl;
        yield return Format;
    }

    public static Result<BookCover> Create(Uri fullSizeImageUrl, Uri thumbnailImageUrl, string format)
    {
        if (string.IsNullOrWhiteSpace(format))
            return Result<BookCover>.Failure(BookCoverErrors.EmptyFormat());
        
        return Result<BookCover>.Success(new BookCover(fullSizeImageUrl, thumbnailImageUrl, format));
    }
}