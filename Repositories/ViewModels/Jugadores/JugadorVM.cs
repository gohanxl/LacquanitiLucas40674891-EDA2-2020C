using System;
using System.ComponentModel.DataAnnotations;

namespace Repositories
{
    internal class JugadorVM
    {
        [Required(ErrorMessage = "El campo de Nombre es obligatorio")]
        [MaxLength(80, ErrorMessage = "El nombre no puede tener mas de 80 caracteres")]
        public string Nombre { get; set; }
    }
}