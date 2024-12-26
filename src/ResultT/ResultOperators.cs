namespace ResultT;

public partial class Result
{
    public static implicit operator Result(Error error) => new Result(error);

    public static implicit operator Result(string errorMessage) => new Error(errorMessage);
    public static implicit operator Result(Exception exception) => new Error(exception.Message, exception);    
}

public partial class Result<T>
{    
    public static implicit operator Result<T>(T value) => new Result<T>(value);
    public static implicit operator Result<T>(Error error) => new Result<T>(error);
    
    public static implicit operator Result<T>(string errorMessage) => new Error(errorMessage);
    public static implicit operator Result<T>(Exception exception) => new Error(exception.Message, exception);
}