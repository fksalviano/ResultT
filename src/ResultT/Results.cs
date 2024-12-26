namespace ResultT;

public class Results
{
    public static Result Ok() => new Result();
    public static Result<T> Ok<T>(T? value) => new Result<T>(value);
    
    public static Error Error(string? message = null, Exception? exception = null) => new Error(message, exception);
    public static Error Error(Exception exception) => new Error(exception.Message, exception);
}