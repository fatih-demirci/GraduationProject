using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Persistence.Repositories
{
    public interface IReadRepository<T> : IQuery<T>, IRepository<T> where T : Entity, new()
    {
        T? Get(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T,
            object>>? include = null, bool enableTracking = true);

        ProjectTo? Get<ProjectTo>(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);

        Task<T?> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>,
            IIncludableQueryable<T, object>>? include = null, bool enableTracking = true);

        Task<ProjectTo?> GetAsync<ProjectTo>(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);

        IPaginate<T> GetList(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>,
            IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T,
                object>>? include = null, int index = 1, int size = 10, bool enableTracking = true);

        IPaginate<ProjectTo> GetList<ProjectTo>(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            int index = 1, int size = 10);

        Task<IPaginate<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>,
            IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            int index = 1, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default);

        Task<IPaginate<ProjectTo>> GetListAsync<ProjectTo>(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            int index = 1, int size = 10, CancellationToken cancellationToken = default);

        IQueryable<ProjectTo> GetListAsyncIQueryable<ProjectTo>(Expression<Func<T, bool>>? predicate = null);
    }
}
