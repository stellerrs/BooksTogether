using BooksTogether.Domain.Common;
using BooksTogether.Domain.Enums;

namespace BooksTogether.Domain.Errors;

public static class AnnotationErrors
{
    private const string Code = "Annotation Errors";

    public static Error EmptyAnnotation() => new Error(Code, "Annotation text cannot be empty.", ErrorType.Validation);
}