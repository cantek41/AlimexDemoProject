using AlimexDAL.Repository;
using System;
using System.Data.Entity;
using System.Linq;

namespace AlimexService
{
    public class BaseService<T> where T : class
    {
        #region Private Fields

        private readonly IRepository<T> _repo;

        #endregion Private Fields

        #region Public Constructors
        public DbContext context()
        {
            return _repo.Context;
        }
        public BaseService(IRepository<T> repo)
        {
            _repo = repo;
        }

        #endregion Public Constructors

        #region Public Methods

        public virtual void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("object");
            _repo.Delete((T)entity);
            _repo.SaveChanges();
        }

        public virtual void DeleteFull(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("object");
            _repo.DeleteFull((T)entity);
            _repo.SaveChanges();
        }

        public virtual IQueryable<T> GetAll()
         {
            return _repo.GetAll();
        }

        public virtual T GetById(string id)
        {
            return _repo.GetById(id);
        }

        public virtual void Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("object");
            _repo.Insert((T)entity);
            _repo.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("object");
            _repo.Update((T)entity);
            _repo.SaveChanges();
        }

        #endregion Public Methods
    }
}