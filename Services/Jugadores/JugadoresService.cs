using Repositories;
using Repositories.Repositories;
using System;
using System.Collections.Generic;

namespace Services.Jugadores
{
    public class JugadoresService<T> where T : class
    {
        JugadoresRepository<T> jugadoresRepository;

        public JugadoresService(ea2Context context)
        {
            ea2Context ctx = context;
            jugadoresRepository = new JugadoresRepository<T>(ctx);
        }

        public void Delete(object id)
        {
            jugadoresRepository.Delete(id);
        }

        public T GetById(object id)
        {
            return jugadoresRepository.GetById(id);
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Insert(T obj)
        {
            jugadoresRepository.Insert(obj);
        }

        public void Save()
        {
            jugadoresRepository.Save();
        }

        public void Update(T obj)
        {
            jugadoresRepository.Update(obj);
        }
        public IEnumerable<T> GetAll()
        {
            return jugadoresRepository.GetAll();
        }
    }
}
