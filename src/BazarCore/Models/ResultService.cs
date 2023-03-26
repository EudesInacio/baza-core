using System.Net;

public class ResultService<T>
{
    public bool Success { get; set; }
    public IEnumerable<string>? Errors { get; set; }
    public HttpStatusCode Status { get; set; }
    public T? Data { get; set; }
    public ResultService<T> Fail(IEnumerable<string>? errors = null, HttpStatusCode status = HttpStatusCode.BadRequest)
    {
        return new ResultService<T>
        {
            Success = false,
            Errors = errors,
            Status = status
        };
    }
    public ResultService<T> Fail(string error = null, HttpStatusCode status = HttpStatusCode.BadRequest)
    {
        return new ResultService<T>
        {
            Success = false,
            Errors = new List<string> { error },
            Status = status,
        };
    }
    public ResultService<T> Good(T data, HttpStatusCode status = HttpStatusCode.OK)
    {
        return new ResultService<T>
        {
            Success = true,
            Data = data,
            Status = status,
        };
    }
}
