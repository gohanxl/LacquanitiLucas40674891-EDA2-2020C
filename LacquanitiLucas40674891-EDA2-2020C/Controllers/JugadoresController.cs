using Repositories;
using Services.Jugadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LacquanitiLucas40674891_EDA2_2020C.Controllers
{
    public class JugadoresController : Controller
    {
        ea2Context context = new ea2Context();
        JugadoresService<Jugador> jugadoresService;

        public JugadoresController()
        {
            jugadoresService = new JugadoresService<Jugador>(context);
        }

        public ActionResult Index()
        {
            IEnumerable<Jugador> jugadores = jugadoresService.GetAll();

            return View("ListaDeJugadores", jugadores);
        }

        [HttpGet]
        public ActionResult AltaJugador()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AltaJugador(Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                jugadoresService.Insert(jugador);
                return Redirect("/Jugadores");
            }

            return View();
        }


    }
}