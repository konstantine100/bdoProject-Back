namespace bdoProject.Domain.Common.Results;

public sealed record class ErrorResults(int Status, string Message)
{
    // 400 - Bad Requests
    public static ErrorResults Invalid(string message) => new (400, message);
    public static ErrorResults Invalid() => new (400, "The information you provided is invalid. Please try again.");
    
    public static ErrorResults ValidationFailed() => new (400, "We couldn't process your request because some required information is missing or invalid. Please check the form for details.");
    
    // 401 - Unauthorized
    public static ErrorResults Unauthorized() => new (401, "Your current session has expired. Please log in again to continue.");
    public static ErrorResults InvalidCredentials() => new (401, "The email or employee id you entered is incorrect. Please try again.");
    
    // 403 - Forbidden
    public static ErrorResults Forbidden() => new(403,
        "You do not have the necessary permission to access this. Contact your administrator for assistance.");

    public static ErrorResults InsufficientPermissions() => new(403,
        "Your account role does not permit this action. Please check your privileges.");

    public static ErrorResults NotFound(string item) => new(404,
        $"We couldn't find the item: {item}. It may have been deleted or the link is incorrect.");
    
    public static ErrorResults NotFoundMessage(string message) => new(404,
        $"{message}");
    
    public static ErrorResults NotFound() => new(404, "The requested item or page could not be found.");
    
    // 409 - Conflict
    public static ErrorResults Conflict(string message) => new(409, $"This operation could not be completed due to a conflict: {message}.");
    
    public static ErrorResults AlreadyExists() => new(409, "This entry already exists. Please choose a different name or unique identifier.");

    public static ErrorResults DoesNotExist() => new(409,  "The item you are trying to modify does not exist. Please refresh your screen and try again.");
}