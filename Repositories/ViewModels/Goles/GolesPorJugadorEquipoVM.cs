using System;
using System.ComponentModel.DataAnnotations;

namespace Repositories
{
    internal class GolesPorJugadorEquipoVM
    {
        [Required]
        [Range(1, 1000, ErrorMessage = "La cantidad de goles no puede ser menor a 1 ni mayor a 1000")]
        public int CantidadGoles { get; set; }
        [Required]
        public string Equipo { get; set; }
        [Required]
        public virtual int IdJugador { get; set; }
    }
}