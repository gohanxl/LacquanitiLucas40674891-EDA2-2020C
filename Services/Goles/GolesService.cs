using Repositories;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Goles
{
    public class GolesService<T> where T : class
    {
        GolesRepository<T> GolesRepository;

        public GolesService(ea2Context context)
        {
            ea2Context ctx = context;
            GolesRepository = new GolesRepository<T>(ctx);
        }

        public void Delete(object id)
        {
            GolesRepository.Delete(id);
        }

        public T GetById(object id)
        {
            return GolesRepository.GetById(id);
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Insert(T obj)
        {
            GolesRepository.Insert(obj);
        }

        public void Save()
        {
            GolesRepository.Save();
        }

        public void Update(T obj)
        {
            GolesRepository.Update(obj);
        }
        public IEnumerable<T> GetAll()
        {
            return GolesRepository.GetAll();
        }

        public GolesPorJugadorEquipo GetShouldUpdateJugadorInEquipo(int? id, string equipo)
        {
            return GolesRepository.GetShouldUpdateJugadorInEquipo(id, equipo);
        }

        public string GetCantidadDeGolesByEquipo(string equipo)
        {
            return GolesRepository.GetCantidadDeGolesByEquipo(equipo);
        }
    }
}
