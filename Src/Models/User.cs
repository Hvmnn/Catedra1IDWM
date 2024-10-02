using System.ComponentModel.DataAnnotations;
using Catedra1IDWM.Src.Services;

namespace Catedra1IDWM.Src.Models
{
    public class User
    {
        public int Id {get; set;}

        [RegularExpression(@"^\d{1,8}-[0-9kK]{1}$", ErrorMessage = "El RUT no tiene un formato válido.")]
        public required string Rut {get; set;}

        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre tiene que estar entre 3 y 100 caracteres")]
        public required string Nombre {get; set;}

        [EmailAddress]
        public required string Correo {get; set;}

        [RegularExpression(@"Masculino|Femenino|Otro|Prefiero no decirlo")]
        public required string Genero {get; set;}

        [FechaMenorQueHoy(ErrorMessage = "La fecha de nacimiento debe ser menor a la fecha actual")]
        public required DateTime FechaNacimiento {get;set;}
    }
}