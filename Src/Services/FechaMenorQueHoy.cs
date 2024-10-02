using System;
using System.ComponentModel.DataAnnotations;

namespace Catedra1IDWM.Src.Services
{
    public class FechaMenorQueHoyAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DateTime fecha)
            {
                return fecha < DateTime.Now;
            }
            return false;
        }

        public override string FormatErrorMessage(string fecha)
        {
            return $"La {fecha} debe ser menor que la fecha actual.";
        }
    }
}

