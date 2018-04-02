using QuizVersus.Core.Data.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace QuizVersus.Core.Repositories.Abstract
{
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : IEntity
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        TEntity FindById(object id);
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        TEntity Delete(TEntity entity);
        TEntity DeleteById(object id);
    }
}