using Microsoft.EntityFrameworkCore;

namespace Core.Persistence.Paging
{
    public static class IQueryablePaginateExtensions
    {
        public static async Task<IPaginate<T>> ToPaginateAsync<T>(this IQueryable<T> source, int index, int size,
                                                              int from = 1, Func<T, object>? distinctBy = null,
                                                              CancellationToken cancellationToken = default)
        {
            if (from > index) throw new ArgumentException($"From: {from} > Index: {index}, must from <= Index");

            int count = await source.CountAsync(cancellationToken).ConfigureAwait(false);

            List<T> items = await source.Skip((index - from) * size).Take(size).ToListAsync(cancellationToken);
            if (distinctBy != null)
                items = items.DistinctBy(distinctBy).ToList();

            Paginate<T> list = new()
            {
                Index = index,
                Size = size,
                From = from,
                Count = count,
                Items = items,
                Pages = (int)Math.Ceiling(count / (double)size)
            };
            return list;
        }

        public static IPaginate<T> ToPaginate<T>(this IQueryable<T> source, int index, int size,
                                                 int from = 1, Func<T, object>? distinctBy = null)
        {
            if (from > index) throw new ArgumentException($"From: {from} > Index: {index}, must from <= Index");

            int count = source.Count();

            List<T> items = source.Skip((index - from) * size).Take(size).ToList();
            if (distinctBy != null)
                items = items.DistinctBy(distinctBy).ToList();

            Paginate<T> list = new()
            {
                Index = index,
                Size = size,
                From = from,
                Count = count,
                Items = items,
                Pages = (int)Math.Ceiling(count / (double)size)
            };
            return list;
        }
    }
}
