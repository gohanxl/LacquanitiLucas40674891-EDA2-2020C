using Repositories;
using Services.Goles;
using Services.Jugadores;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LacquanitiLucas40674891_EDA2_2020C.Controllers
{
    public class GolesController : Controller
    {
        // GET: Goles
        ea2Context context = new ea2Context();
        GolesService<GolesPorJugadorEquipo> golesService;
        JugadoresService<Jugador> jugadorService;

        public GolesController()
        {
            golesService = new GolesService<GolesPorJugadorEquipo>(context);
            jugadorService = new JugadoresService<Jugador>(context);
        }
        public ActionResult Index()
        {
            IEnumerable<GolesPorJugadorEquipo> goles = golesService.GetAll();

            return View("ListaGolesJugador", goles);
        }

        [HttpGet]
        public ActionResult AltaGolesJugador()
        {
            CargarJugadoresEnViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult AltaGolesJugador(GolesPorJugadorEquipo goles)
        {
            if (ModelState.IsValid)
            {
                var ShouldUpdateGoles = golesService.GetShouldUpdateJugadorInEquipo(goles.IdJugador, goles.Equipo);

                if (ShouldUpdateGoles != null)
                {
                    ShouldUpdateGoles.CantidadGoles = goles.CantidadGoles;
                    golesService.Update(goles);
                    return Redirect("/Goles");
                }

                golesService.Insert(goles);
                return Redirect("/Goles");
            }

            return View();
        }

        private void CargarJugadoresEnViewBag()
        {
            IEnumerable<Jugador> jugadores = jugadorService.GetAll();
            ViewBag.Jugadores = jugadores;
        }
    }
}