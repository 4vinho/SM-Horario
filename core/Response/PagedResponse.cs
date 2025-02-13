namespace SM_Horarios;

public class PagedResponse<TData> : Response<TData>
{
    public int PageSize { get; set; }
    public int PageCount { get; set; }

    public PagedResponse(int code, string message, TData data, int pageSize = 1, int pageCount = 0)
        : base(code, message, data)
    {
        PageCount = pageCount;
        PageSize = pageSize > 0 ? pageSize : 1;
    }
}
