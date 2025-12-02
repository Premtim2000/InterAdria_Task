using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.Wrappers;
public class Result<T> where T : class
{
    public T? Data { get; private set; }
    public Error? Error { get; private set; }
    public bool HasError => Error != null;
    public bool IsSuccessful => Error == null;

    public static Result<T> Successful(T data)
    {
        return new() { Data = data };
    }

    public static Result<T> Fail(Error error)
    {
        return new() { Data = null, Error = error };
    }
}