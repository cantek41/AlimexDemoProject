using System;
using System.Data.Entity;
using System.Linq;

namespace AlimexDAL.Repository
{
    public interface IRepository<TEntity>
    {
        #region Public Methods

        DbContext Context { get; }

        IQueryable<TEntity> GetAll();

        TEntity GetById(string Id);
 

        void Insert(TEntity entity);

        void Update(TEntity entity, bool modify = true);

        void Delete(TEntity entity);
        void DeleteFull(TEntity entity);
        
        void SaveChanges();

        void Dispose();
        #endregion Public Methods
    }
}