using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Examen2.Models
{
    public class AutomovilModel
    {
        [Required(ErrorMessage = "Debe ingresar una marca para el automovil")]
        [DisplayName("Marca")]
        public string? Marca { get; set; }

        [Required(ErrorMessage = "Debe ingresar un modelo para el automovil")]
        [DisplayName("Modelo")]
        public string? Modelo { get; set; }

        [Required(ErrorMessage = "Debe ingresar un color para el automovil")]
        [DisplayName("Color")]
        public string? Color { get; set; }

        [Required(ErrorMessage = "Debe ingresar la cantidad de puertas del automovil")]
        [DisplayName("Cantidad de puertas")]
        [Range(1, 5, ErrorMessage = "Debe ingresar un número válido (entre 1 y 5)")]
        public int? NumeroPuertas { get; set; }


        [Required(ErrorMessage = "Debe indicar si es o no doble tracción")]
        [DisplayName("¿Es doble tracción?")]
        public bool? DobleTraccion { get; set; }


    }
}
