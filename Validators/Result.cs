namespace DiamondStore.Validators;
public class Result
{
    private readonly string? _errorMsg;
    public bool IsSucess { get; }
    public bool IsFailure => !IsSucess;

    protected Result(string? errorMsg, bool isSuccess)
    {
        _errorMsg = errorMsg;
        IsSucess = isSuccess;
    }

    public string ErrorMsg
    {
        get => IsFailure ? _errorMsg! : throw new InvalidOperationException("Can not acess errorMsg from a Success result");
    }

    public static Result Success() => new Result(null!, true);
    public static Result Failure(string errorMsg) => new Result(errorMsg, false);
}

public class Result<T> : Result
{
    private Result(T? value, string? errorMsg, bool isSucess) : base(errorMsg, isSucess)
    {
        _value = value;
    }

    private readonly T? _value;

    public T Value
    {
        get => IsSucess ? _value! : throw new InvalidOperationException("Can not acess fail result value");
    }

    public static Result<T> Success(T value) => new Result<T>(value, null, true);
    public static new Result<T> Failure(string errorMsg) => new Result<T>(default ,errorMsg, false);
}