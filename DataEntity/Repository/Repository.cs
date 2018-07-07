using DataEntityManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity.Validation;

namespace DataEntity.Repository
{
    public abstract class Repository <T> : IRepository<T>where T : BaseClass
    {
        protected readonly DataContext context;

        public Repository()
        {
            this.context = new DataContext();
        }

        public void Delete(T entity)
        {

            context.Set<T>().Remove(entity);
            this.Save();

        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public virtual T GetById<T2>(T2 id) where T2 : struct
        {
            return context.Set<T>().Find(id);
        }

        public T Insert(T entity)
        {
            var savedEntity = context.Set<T>().Add(entity);
            this.Save();
            return savedEntity;
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> result = context.Set<T>().Where(predicate);
            return result;
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this.Save();
        }

        public void Save()
        {
            try
            {
                this.context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {

                        Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName,validationError.ErrorMessage);
                    }
                }
            }
        }

  
    }
}

