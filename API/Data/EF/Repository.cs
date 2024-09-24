using Data.Abstract;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Z.EntityFramework.Extensions;

namespace Data.EF
{
    public interface IRepository : IDisposable
    {
        #region Get

        TEntity Get<TEntity>(string id, params Expression<Func<TEntity, object>>[] propertySelectors) where TEntity : BaseEntity;

        TEntity Get<TEntity>(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] propertySelectors) where TEntity : BaseEntity;

        Task<TEntity> GetAsync<TEntity>(string id, params Expression<Func<TEntity, object>>[] propertySelectors) where TEntity : BaseEntity;

        Task<TEntity> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] propertySelectors) where TEntity : BaseEntity;

        #endregion Get

        #region GetAll

        IQueryable<TEntity> GetAll<TEntity>() where TEntity : BaseEntity;

        IQueryable<TEntity> GetAll<TEntity>(params Expression<Func<TEntity, object>>[] propertySelectors) where TEntity : BaseEntity;

        IQueryable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] propertySelectors) where TEntity : BaseEntity;

        #endregion GetAll

        #region Insert

        TEntity Insert<TEntity>(TEntity entity) where TEntity : BaseEntity;

        void Insert<TEntity>(List<TEntity> entities) where TEntity : BaseEntity;

        Task<TEntity> InsertAsync<TEntity>(TEntity entity) where TEntity : BaseEntity;

        Task InsertAsync<TEntity>(List<TEntity> entities) where TEntity : BaseEntity;

        Task<bool> BulkInsertAsync<TEntity>(List<TEntity> entities) where TEntity : BaseEntity;

        #endregion Insert

        #region Update

        TEntity Update<TEntity>(TEntity entity) where TEntity : BaseEntity;

        void Update<TEntity>(List<TEntity> entities) where TEntity : BaseEntity;

        #endregion Update

        #region Delete

        TEntity Delete<TEntity>(string id) where TEntity : BaseEntity;

        TEntity Delete<TEntity>(TEntity entity) where TEntity : BaseEntity;

        void Delete<TEntity>(List<TEntity> entities) where TEntity : BaseEntity;

        #endregion Delete

        #region Other

        /// <summary>
        /// Lấy giá trị lớn nhất của cột SortOrder
        /// </summary>
        int GetMaxStt<TEntity>(Expression<Func<TEntity, int>> exp) where TEntity : BaseEntity;

    #endregion Other
    MDPDbContext GetDbContext();
        DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class;
    }

    public class Repository : IRepository
    {
        private readonly MDPDbContext _dbContext;

        public Repository(MDPDbContext dbContext)
        {
            _dbContext = dbContext;

        }
       
        //get dbcontext
        public MDPDbContext GetDbContext()
        {
            return _dbContext;
        }

        public DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class
        {
            return _dbContext.Set<TEntity>();
        }

        #region Get

        public TEntity Get<TEntity>(string id, params Expression<Func<TEntity, object>>[] propertySelectors) where TEntity : BaseEntity
        {
            return GetAll(propertySelectors).SingleOrDefault(x => x.Id == id);
        }

        public TEntity Get<TEntity>(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] propertySelectors) where TEntity : BaseEntity
        {
            return GetAll(predicate, propertySelectors).FirstOrDefault();
        }

        public async Task<TEntity> GetAsync<TEntity>(string id, params Expression<Func<TEntity, object>>[] propertySelectors) where TEntity : BaseEntity
        {
            return await GetAll(propertySelectors).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TEntity> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] propertySelectors) where TEntity : BaseEntity
        {
            return await GetAll(predicate, propertySelectors).FirstOrDefaultAsync();
        }

        #endregion Get

        #region GetAll

        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : BaseEntity
        {
            if (typeof(TEntity).GetInterfaces().Contains(typeof(IHasSoftDelete)))
                return _dbContext.Set<TEntity>().Where(x => ((IHasSoftDelete)x).IsDeleted == false);

            return _dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll<TEntity>(params Expression<Func<TEntity, object>>[] propertySelectors) where TEntity : BaseEntity
        {
            var query = GetAll<TEntity>();

            if (propertySelectors != null)
            {
                foreach (var includeProperty in propertySelectors)
                    query = query.Include(includeProperty);
            }

            return query;
        }

        public IQueryable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] propertySelectors) where TEntity : BaseEntity
        {
            return GetAll(propertySelectors).Where(predicate);
        }


        #endregion GetAll

        #region Insert

        public TEntity Insert<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            return _dbContext.Set<TEntity>().Add(entity).Entity;
        }

        public void Insert<TEntity>(List<TEntity> entities) where TEntity : BaseEntity
        {
            _dbContext.Set<TEntity>().AddRange(entities);
        }

        public async Task<TEntity> InsertAsync<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            var entityEntry = await _dbContext.Set<TEntity>().AddAsync(entity);
            return entityEntry.Entity;
        }

        public async Task InsertAsync<TEntity>(List<TEntity> entities) where TEntity : BaseEntity
        {
            await _dbContext.Set<TEntity>().AddRangeAsync(entities);
        }

        public async Task<bool> BulkInsertAsync<TEntity>(List<TEntity> entities) where TEntity : BaseEntity
        {
            var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                await _dbContext.BulkInsertAsync<TEntity>(entities, options => options.IncludeGraph = true);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return false;
            }
        }


        #endregion Insert

        #region Update

        public TEntity Update<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            return _dbContext.Set<TEntity>().Update(entity).Entity;
        }

        public void Update<TEntity>(List<TEntity> entities) where TEntity : BaseEntity
        {
            _dbContext.Set<TEntity>().UpdateRange(entities);
        }

        #endregion Update

        #region Delete

        public TEntity Delete<TEntity>(string id) where TEntity : BaseEntity
        {
            var entity = Get<TEntity>(id);
            return Delete(entity);
        }

        public TEntity Delete<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            if (typeof(TEntity).GetInterfaces().Contains(typeof(IHasSoftDelete)))
            {
                ((IHasSoftDelete)entity).IsDeleted = true;
                return Update(entity);
            }

            return _dbContext.Set<TEntity>().Remove(entity).Entity;
        }

        public void Delete<TEntity>(List<TEntity> entities) where TEntity : BaseEntity
        {
            foreach (var entity in entities)
                Delete(entity);
        }

        #endregion Delete

        #region disposed

        private bool disposed = false;

        protected void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion disposed

        #region Other

        public int GetMaxStt<TEntity>(Expression<Func<TEntity, int>> exp) where TEntity : BaseEntity
        {
            if (_dbContext.Set<TEntity>().Any())
                return _dbContext.Set<TEntity>().Max(exp);
            return 0;
        }

        #endregion Other
    }
}
