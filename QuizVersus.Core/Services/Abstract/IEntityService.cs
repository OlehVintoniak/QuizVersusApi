using QuizVersus.Core.Data.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace QuizVersus.Core.Services.Abstract
{
    public interface IEntityService<TEntity> : IService where TEntity : IEntity
    {
        TEntity Add(TEntity entity);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        TEntity FindById(object id);
        void Update(TEntity entity);
        TEntity Delete(TEntity entity);
        TEntity DeleteById(object id);
    }
}
