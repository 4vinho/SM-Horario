namespace SM_Horarios;

public class PagedResponse<TData> : Response<TData>
{
    public int PageSize { get; set; }
    public int TotalPage { get; set; }
    public int PageCount { get; set; }

    public PagedResponse(int code, string message, TData data, int pageSize = 0, int pageCount = 0)
        : base(code, message, data)
    {
        TotalPage = (pageCount + pageSize - 1) / pageSize;

        PageSize = pageSize;
        PageCount = pageCount;
    }
}
