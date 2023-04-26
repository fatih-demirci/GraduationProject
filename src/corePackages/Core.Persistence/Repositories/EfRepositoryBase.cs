using AutoMapper;
using AutoMapper.AspNet.OData;
using AutoMapper.QueryableExtensions;
using Core.Persistence.Paging;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
                                                           int index = 1, int size = 10, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = Query();
            queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null) queryable = orderBy(queryable);
            IQueryable<ProjectTo> projectQueryble = queryable.ProjectTo<ProjectTo>(_mapper.ConfigurationProvider);
            IPaginate<ProjectTo>? projectTo = await projectQueryble.ToPaginateAsync(index, size, 1, cancellationToken);
            return projectTo;

        }

        public async Task<IPaginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null,
                                                   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy =
                                                       null,
                                                   Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>?
                                                       include = null,
                                                   int index = 1, int size = 10, bool enableTracking = true,
                                                   CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = Query();
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null) queryable = orderBy(queryable);
            return await queryable.ToPaginateAsync(index, size, 1, cancellationToken);
        }

        public async Task<List<ProjectTo>> GetListAsync<ProjectTo>(ODataQueryOptions<ProjectTo> options, Expression<Func<TEntity, bool>>? predicate = null)
            where ProjectTo : class, new()
        {
            IQueryable<TEntity> queryable = Query();
            if (predicate != null) queryable = queryable.Where(predicate);
            IQueryable<ProjectTo> projectToQueryable = await queryable.GetQueryAsync(_mapper, options);

            return await projectToQueryable.ToListAsync();
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
                                          int index = 1, int size = 10)
        {
            IQueryable<TEntity> queryable = Query();
            queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null) queryable = orderBy(queryable);
            IQueryable<ProjectTo> projectQueryble = queryable.ProjectTo<ProjectTo>(_mapper.ConfigurationProvider);
            IPaginate<ProjectTo> projectTo = projectQueryble.ToPaginate(index, size);
            return projectTo;
        }

        public IPaginate<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate = null,
                                  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                  Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                  int index = 1, int size = 10, bool enableTracking = true)
        {
            IQueryable<TEntity> queryable = Query();
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null) queryable = orderBy(queryable);
            return queryable.ToPaginate(index, size);
        }

        public TEntity Add(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return entity;
        }
    }
}
