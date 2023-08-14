namespace Common.Queries;

public class PaginationDto<T> where T : class
{
    public int Count { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public IEnumerable<T> Data { get; set; }
    public int PageCount { get; set; }
    public int ResultByPage { get; set; }
}

