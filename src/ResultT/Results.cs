using System.Net;

namespace ResultT;

public class Results
{
    public static Result Ok() => new Result();
    public static Result<T> Ok<T>(T? value) => new Result<T>(value);
    
    public static Error Error(string? message = null, Exception? exception = null, HttpStatusCode? statusCode = null) => new Error(message, exception, statusCode);
    public static Error Error(string? message, HttpStatusCode? statusCode) => new Error(message, null, statusCode);
    public static Error Error(Exception exception) => new Error(exception.Message, exception);
}