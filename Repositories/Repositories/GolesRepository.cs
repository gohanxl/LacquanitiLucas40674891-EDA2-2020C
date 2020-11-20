using Repositories.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace Repositories.Repositories
{
    public class GolesRepository<T> : IEnumerable<T>, IRepository<T> where T : class
    {
        ea2Context ctx;
        private DbSet<T> defaultObject;

        public GolesRepository(ea2Context context)
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
            defaultObject.Attach(obj);
            Save();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public GolesPorJugadorEquipo GetShouldUpdateJugadorInEquipo(int? id, string equipo)
        {
            var parsedEquipo = equipo.ToUpper();
            var rowsWithJugadorId = ctx.GolesPorJugadorEquipo.FirstOrDefault(row => row.IdJugador == id && row.Equipo.ToUpper() == parsedEquipo);

            return rowsWithJugadorId;
        }

        public string GetCantidadDeGolesByEquipo(string equipo)
        {
            int golesByEquipo = ctx.GolesPorJugadorEquipo
                            .Where(g => g.Equipo.ToUpper() == equipo.ToUpper())
                            .GroupBy(g => g.Equipo)
                            .Select(g => g.Sum(c => c.CantidadGoles))
                            .First();

            return golesByEquipo.ToString();
        }
    }
}
