using Microsoft.EntityFrameworkCore;

namespace BazarCore.Utils
{
    public static class PageListHelper
    {
        public static async Task<PaginatedList<TList>> GetPaginatedList<TList>(this IQueryable<TList> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<TList>(items, count, pageIndex, pageSize);
        }
    }
}
