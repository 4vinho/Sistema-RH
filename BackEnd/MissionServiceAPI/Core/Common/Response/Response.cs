namespace MissionServiceAPI;

public class Response<TData>
{
    public TData Data { get; set; }
    public int Code { get; set; }
    public bool IsSuccess { get; set; }
    public string Message { get; set; }

    public Response(int code, string message, TData data)
    {
        Code = code;
        Message = message;
        Data = data;

        IsSuccess = Code <= 399;
    }
}
