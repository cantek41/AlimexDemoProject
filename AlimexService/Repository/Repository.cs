using AlimexIdentity.Controller;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace AlimexDAL.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {

        protected readonly AppDbContext _context;


        protected DbSet<TEntity> _dbSet;

        public DbContext Context
        {
            get
            {
                return this._context;
            }
        }

        public Repository(AppDbContext context)
        {

            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public virtual TEntity GetById(string id)
        {
            return _dbSet.Find(id);
        }


        public virtual void Insert(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            var entityType = entity.GetType();
            var now = DateTime.Now;
            var property = entityType.GetProperty("CreatedDate");
            if (property != null)
                property.SetValue(entity, now, null);
            property = entityType.GetProperty("CreatedUser");
            if (property != null)
                property.SetValue(entity,Identity.getUserId(), null);


            property = entity.GetType().GetProperty("ModifiedUser");
            if (property != null)
                property.SetValue(entity, Identity.getUserId());

            property = entity.GetType().GetProperty("ModifiedDate");
            if (property != null)
                property.SetValue(entity, DateTime.Now);
           

            _dbSet.Add(entity);
        }

        public void Update(TEntity entity, bool modify = true)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            var property = entity.GetType().GetProperty("ModifiedUser");
            if (property != null)
                property.SetValue(entity, Identity.getUserId());

            if (modify)
            {
                property = entity.GetType().GetProperty("ModifiedDate");
                if (property != null)
                    property.SetValue(entity, DateTime.Now);
            }

            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            var property = entity.GetType().GetProperty("ModifiedDate");
            if (property != null)
                property.SetValue(entity, DateTime.Now);

            property = entity.GetType().GetProperty("IsDeleted");
            if (property != null)
                property.SetValue(entity, true, null);
            else
                _dbSet.Remove(entity);
        }


        public virtual void DeleteFull(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            _dbSet.Remove(entity);

        }

        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();

            }
            catch (DbEntityValidationException dbEx)
            {
                string errorMessage = string.Empty;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }
                throw new Exception(errorMessage, dbEx);
            }

        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (_context == null) return;
            _context.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private int GetIso8601WeekOfYear(DateTime time)
        {
           
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

    }
}