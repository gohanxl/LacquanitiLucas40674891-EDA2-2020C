using Repositories;
using Services.Goles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace LacquanitiLucas40674891_EDA2_2020C.Controllers
{
    public class CantidadTotalGolesEquipoApiController : ApiController
    {
        GolesService<GolesPorJugadorEquipo> golesService;

        public CantidadTotalGolesEquipoApiController()
        {
            ea2Context context = new ea2Context();
            golesService = new GolesService<GolesPorJugadorEquipo>(context);
        }

        [HttpGet]
        public string Get(string equipo)
        {
            return golesService.GetCantidadDeGolesByEquipo(equipo);
        }
    }
}