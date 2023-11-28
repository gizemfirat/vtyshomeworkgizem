namespace Vtys.Core.Results
{
    public interface IResult
    {
        bool IsSuccess { get; }

        string Message { get; }

        object? Data { get; }
    }
}
