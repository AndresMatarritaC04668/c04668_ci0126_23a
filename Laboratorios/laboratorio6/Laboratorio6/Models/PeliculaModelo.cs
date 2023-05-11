using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Laboratorio6.Models
{
    public class PeliculaModelo
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Debe ingresar un nombre")]
        [DisplayName("Nombre de la película")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar un año")]
        [DisplayName("Año:")]
        [RegularExpression("^(18|19|20)[0-9]{2}$",ErrorMessage = "Ingrese un año valido")]
        public int Año { get; set; }
    }
}
