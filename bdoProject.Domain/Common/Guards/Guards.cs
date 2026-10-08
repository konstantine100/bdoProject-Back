using bdoProject.Domain.Common.Results;

namespace bdoProject.Domain.Common.Guards;

public static class Guards
{
    public static Result AgainstNullOrEmpty(string? value, ErrorResults errors) =>
        string.IsNullOrWhiteSpace(value) ? Result.Failure(errors) : Result.Success();
    
    public static Result AgainstRegex(string value, string pattern, ErrorResults errors) => 
        !System.Text.RegularExpressions.Regex.IsMatch(value, pattern) 
            ? Result.Failure(errors) 
            : Result.Success();

    public static Result AgainstStringRange(string value, int min, int max, ErrorResults errors)
    {
        if (string.IsNullOrWhiteSpace(value)) return Result.Failure(errors);
        
        return value.Length < min || value.Length > max
            ? Result.Failure(errors)
            : Result.Success();
    }

    public static Result AgainstOutOfRange(int value, int min, int max, ErrorResults errors)
    {
        return value < min || value > max 
            ? Result.Failure(errors)
            : Result.Success();
    }

    public static Result AgainstEqualStringLength(string value, int exactLength, ErrorResults errors)
    {
        if(string.IsNullOrWhiteSpace(value)) return Result.Failure(errors);
        
        return value.Length != exactLength
            ? Result.Failure(errors)
            : Result.Success();
    }
}