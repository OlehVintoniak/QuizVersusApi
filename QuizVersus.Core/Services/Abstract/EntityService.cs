using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using QuizVersus.Core.Data.Entities.Abstract;
using QuizVersus.Core.Repositories.Abstract;

namespace QuizVersus.Core.Services.Abstract
{
    public abstract class EntityService<TRepo, TEntity> : IEntityService<TEntity>
        where TEntity : class, IEntity
        where TRepo : IGenericRepository<TEntity>
    {
        private readonly TRepo _repository;
        protected TRepo Repository
        {
            get { return _repository; }
        }

        private readonly IUnitOfWork _unitOfWork;
        protected IUnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }

        protected  EntityService(IUnitOfWork unitOfWork, TRepo repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public virtual TEntity Add(TEntity entity)
        {
            ValidateEntity(entity);
            TEntity addedEntity = Repository.Add(entity);
            UnitOfWork.Commit();
            return addedEntity;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Repository.GetAll();
        }

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return Repository.FindBy(predicate);
        }

        public TEntity FindById(object id)
        {
            return Repository.FindById(id);
        }

        public void Update(TEntity entity)
        {
            ValidateEntity(entity);
            Repository.Update(entity);
            UnitOfWork.Commit();
        }

        public TEntity Delete(TEntity entity)
        {
            ValidateEntity(entity);
            TEntity deletedEntity = Repository.Delete(entity);
            UnitOfWork.Commit();
            return deletedEntity;
        }

        public TEntity DeleteById(object id)
        {
            TEntity deletedEntity = Repository.DeleteById(id);
            UnitOfWork.Commit();
            return deletedEntity;
        }

        private void ValidateEntity(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
        }
    }
}
