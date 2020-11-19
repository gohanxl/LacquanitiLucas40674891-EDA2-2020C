using Repositories.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace Repositories.Repositories
{
    public class JugadoresRepository<T> : IEnumerable<T>, IRepository<T> where T : class
    {
        ea2Context ctx;
        private DbSet<T> defaultObject;

        public JugadoresRepository(ea2Context context)
        {
            ctx = context;
            defaultObject = ctx.Set<T>();
        }

        public void Delete(object id)
        {
            T currentObject = defaultObject.Find(id);
            defaultObject.Remove(currentObject);
            Save();
        }

        public T GetById(object id)
        {
            return defaultObject.Find(id);
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Insert(T obj)
        {
            defaultObject.Add(obj);
            Save();
        }

        public IEnumerable<T> GetAll()
        {
            return defaultObject.ToList();
        }

        public void Save()
        {
            try
            {
                ctx.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                var fullErrorMessage = string.Join("; ", errorMessages);

                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

        public void Update(T obj)
        {
            defaultObject.Add(obj);
            ctx.Entry(obj).State = EntityState.Modified;
            Save();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
