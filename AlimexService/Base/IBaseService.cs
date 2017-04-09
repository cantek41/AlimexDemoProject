using System;
using System.Data.Entity;
using System.Linq;

namespace AlimexService
{
    public interface IBaseService<T>
    {
        #region Public Methods

        void Delete(T entity);
        void DeleteFull(T entity);

        IQueryable<T> GetAll();

        T GetById(string id);

        void Insert(T entity);

        void Update(T entity);

        DbContext context();

        #endregion Public Methods
    }
}