using AutoMapper;
using AutoMapper.AspNet.OData;
using AutoMapper.QueryableExtensions;
using Core.Persistence.Paging;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Persistence.Repositories
{
    public class EfRepositoryBase<TEntity, TContext> : IWriteRepository<TEntity>, IReadRepository<TEntity>
        where TContext : DbContext, IUnitOfWork
        where TEntity : Entity, new()
    {
        protected TContext Context { get; set; }

        public IUnitOfWork UnitOfWork => Context;
        private readonly IMapper _mapper;

        public EfRepositoryBase(TContext context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }

        public async Task<ProjectTo?> GetAsync<ProjectTo>(Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> queryable = Query();
            queryable = queryable.AsNoTracking();
            if (predicate != null) queryable = queryable.Where(predicate);
            if (include != null) queryable = include(queryable);
            IQueryable<ProjectTo> ProjectToQueryable = queryable.ProjectTo<ProjectTo>(_mapper.ConfigurationProvider);
            ProjectTo? projectTo = await ProjectToQueryable.FirstOrDefaultAsync();
            return projectTo;
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool enableTracking = true)
        {
            IQueryable<TEntity> queryable = Query();
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (predicate != null) queryable = queryable.Where(predicate);
            if (include != null) queryable = include(queryable);
            return await queryable.FirstOrDefaultAsync();
        }

        public async Task<IPaginate<ProjectTo>> GetListAsync<ProjectTo>(Expression<Func<TEntity, bool>>? predicate = null,
                                                           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy =
                                                               null,
                                                           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>?
                                                               include = null,
                                                           int index = 1, int size = 10, Func<ProjectTo, object>? distinctBy = null,
                                                           CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = Query();
            queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null) queryable = orderBy(queryable);
            IQueryable<ProjectTo> projectQueryble = queryable.ProjectTo<ProjectTo>(_mapper.ConfigurationProvider);
            IPaginate<ProjectTo>? projectTo = await projectQueryble.ToPaginateAsync(index, size, 1, distinctBy, cancellationToken);
            return projectTo;

        }

        public async Task<IPaginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null,
                                                   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy =
                                                       null,
                                                   Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>?
                                                       include = null,
                                                   int index = 1, int size = 10, bool enableTracking = true,
                                                   Func<TEntity, object>? distinctBy = null,
                                                   CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = Query();
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null) queryable = orderBy(queryable);

            return await queryable.ToPaginateAsync(index, size, 1, distinctBy, cancellationToken);
        }

        public async Task<List<ProjectTo>> GetListAsync<ProjectTo>(ODataQueryOptions<ProjectTo> options, Expression<Func<TEntity, bool>>? predicate = null)
            where ProjectTo : class, new()
        {
            IQueryable<TEntity> queryable = Query();
            if (predicate != null) queryable = queryable.Where(predicate);
            IQueryable<ProjectTo> projectToQueryable = await queryable.GetQueryAsync(_mapper, options);

            return await projectToQueryable.ToListAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? predicate = null)
        {
            IQueryable<TEntity> queryable = Query();
            if (predicate != null) queryable = queryable.Where(predicate);
            return await queryable.AnyAsync();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> queryable = Query();
            if (predicate != null) queryable = queryable.Where(predicate);
            return await queryable.CountAsync();
        }

        public IQueryable<TEntity> Query()
        {
            return Context.Set<TEntity>();
        }

        public ProjectTo? Get<ProjectTo>(Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> queryable = Query();
            queryable = queryable.AsNoTracking();
            if (predicate != null) queryable = queryable.Where(predicate);
            if (include != null) queryable = include(queryable);
            IQueryable<ProjectTo> projectQueryble = queryable.ProjectTo<ProjectTo>(_mapper.ConfigurationProvider);
            ProjectTo? projectTo = projectQueryble.FirstOrDefault();
            return projectTo;
        }

        public TEntity? Get(Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool enableTracking = true)
        {
            IQueryable<TEntity> queryable = Query();
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (predicate != null) queryable = queryable.Where(predicate);
            if (include != null) queryable = include(queryable);
            return queryable.FirstOrDefault();
        }

        public IPaginate<ProjectTo> GetList<ProjectTo>(Expression<Func<TEntity, bool>>? predicate = null,
                                          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                          Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                          Func<ProjectTo, object>? distinctBy = null,
                                          int index = 1, int size = 10)
        {
            IQueryable<TEntity> queryable = Query();
            queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null) queryable = orderBy(queryable);
            IQueryable<ProjectTo> projectQueryble = queryable.ProjectTo<ProjectTo>(_mapper.ConfigurationProvider);
            IPaginate<ProjectTo> projectTo = projectQueryble.ToPaginate(index, size, 1, distinctBy);
            return projectTo;
        }

        public IPaginate<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate = null,
                                  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                  Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                  Func<TEntity, object>? distinctBy = null,
                                  int index = 1, int size = 10, bool enableTracking = true)
        {
            IQueryable<TEntity> queryable = Query();
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null) queryable = orderBy(queryable);
            return queryable.ToPaginate(index, size, 1, distinctBy);
        }

        public bool Any(Expression<Func<TEntity, bool>>? predicate = null)
        {
            IQueryable<TEntity> queryable = Query();
            if (predicate != null) queryable = queryable.Where(predicate);
            return queryable.Any();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> queryable = Query();
            if (predicate != null) queryable = queryable.Where(predicate);
            return queryable.Count();
        }

        public TEntity Add(TEntity entity)
        {
            Context.Add(entity);
            return entity;
        }

        public IList<TEntity> AddRange(IList<TEntity> entities)
        {
            Context.AddRange(entities);
            return entities;
        }

        public TEntity Update(TEntity entity)
        {
            Context.Update(entity);
            return entity;
        }

        public IList<TEntity> UpdateRange(IList<TEntity> entities)
        {
            Context.UpdateRange(entities);
            return entities;
        }

        public TEntity Delete(TEntity entity)
        {
            Context.Remove(entity);
            return entity;
        }

        public IList<TEntity> DeleteRange(IList<TEntity> entities)
        {
            Context.RemoveRange(entities);
            return entities;
        }
    }
}
