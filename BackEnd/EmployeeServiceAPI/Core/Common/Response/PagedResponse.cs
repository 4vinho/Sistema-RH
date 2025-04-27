namespace EmployeeServiceAPI;

public class PagedResponse<TData> : Response<TData>
{
    public int PageSize { get; set; }
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }

    public PagedResponse(int code, string message, TData data, int pageSize, int totalItems)
        : base(code, message, data)
    {
        PageSize = pageSize > 0 ? pageSize : 1;
        TotalItems = totalItems >= 0 ? totalItems : 0;
        TotalPages = (int)Math.Ceiling((double)TotalItems / PageSize);
    }
}

