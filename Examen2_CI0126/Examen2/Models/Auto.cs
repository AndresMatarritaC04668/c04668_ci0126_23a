using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Examen2.Models
{
    public class Automovil
    {
        [Required(ErrorMessage = "Debe ingresar una marca para el automovil")]
        [DisplayName("Marca del automovil")]
        public string? Marca { get; set; }

        [Required(ErrorMessage = "Debe ingresar un modelo para el automovil")]
        [DisplayName("Modelo del automovil")]
        public string? Modelo { get; set; }

        [Required(ErrorMessage = "Debe ingresar un color para el automovil")]
        [DisplayName("Color del automovil")]
        public string? Color { get; set; }

        [Required(ErrorMessage = "Debe ingresar la cantidad de puertas del automovil")]
        [DisplayName("Cantidad de puertas")]
        [Range(1, 5, ErrorMessage = "Debe ingresar un número válido (entre 1 y 10)")]
        public int NumeroPuertas { get; set; }


        [Required(ErrorMessage = "Debe indicar si es o no doble tracción")]
        [DisplayName("¿Es doble tracción?")]
        [Range(typeof(bool), "false", "true", ErrorMessage = "El valor debe ser 'true' o 'false'")]
        public bool DobleTraccion { get; set; }


    }
}
