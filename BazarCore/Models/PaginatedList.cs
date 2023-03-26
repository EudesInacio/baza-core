using Microsoft.EntityFrameworkCore;

public class PaginatedList<T>
{
    public List<T> Items { get; private set; }
    public int TotalItems { get; private set; }
    public int PageIndex { get; private set; }
    public int TotalPages { get; private set; }
    public PaginatedList() { }
    public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
    {
        PageIndex = pageIndex;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);

        TotalItems = count;
        Items = items;
    }

    public bool HasPreviousPage
    {
        get
        {
            return (PageIndex > 1);
        }
    }

    public bool HasNextPage
    {
        get
        {
            return (PageIndex < TotalPages);
        }
    }
}
