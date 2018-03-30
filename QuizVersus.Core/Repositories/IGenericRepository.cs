using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using QuizVersus.Core.Data.Entities.Abstract;

namespace QuizVersus.Core.Repositories
{
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : IEntity
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        TEntity Find(object id);
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        TEntity Delete(TEntity entity);
        TEntity DeleteById(object id);
    }
}