﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using QuizVersus.Core.Data;
using QuizVersus.Core.Data.Entities.Abstract;

namespace QuizVersus.Core.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly DbSet<TEntity> _dbSet;
        protected DbSet<TEntity> DbSet
        {
            get { return _dbSet; }
        }
        protected readonly ApplicationDbContext Context;
        protected IUnitOfWork UnitOfWork { get; }
        protected GenericRepository(ApplicationDbContext сontext, IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            Context = сontext;
            if (Context != null)
            {
                _dbSet = Context.Set<TEntity>();
            }
        }

        protected GenericRepository(ApplicationDbContext context, DbSet<TEntity> dbSet)
        {
            Context = context;
            _dbSet = dbSet;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.AsEnumerable();
        }

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).AsEnumerable();
        }

        public virtual TEntity Find(object id)
        {
            return DbSet.Find(id);
        }

        public virtual TEntity Add(TEntity entity)
        {
            var addedEntity = DbSet.Add(entity);
            UnitOfWork.CommitAsync();
            return addedEntity;
        }

        public virtual void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            UnitOfWork.Commit();
        }

        public virtual TEntity Delete(TEntity entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            var result = DbSet.Remove(entity);
            UnitOfWork.Commit();
            return result;
        }

        public virtual TEntity DeleteById(object id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            return Delete(entityToDelete);
        }

        #region IDisposable

        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            _disposed = true;
        }

        #endregion
    }
}
