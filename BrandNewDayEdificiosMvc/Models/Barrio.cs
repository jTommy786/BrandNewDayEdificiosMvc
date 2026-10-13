using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrandNewDayEdificiosMvc.Models
{
    public class Barrio
    {
        
            [Key]
            public int BarrioId { get; set; }

            [Required(ErrorMessage = "El nombre es obligatorio.")]
            [StringLength(60, ErrorMessage = "El nombre no puede superar los 60 caracteres.")]
            [Display(Name = "Nombre del Barrio")]
            public string Nombre { get; set; }

            [Display(Name = "Descripción")]
            public string Descripcion { get; set; }

            // Relación: Un barrio contiene muchos edificios
            public virtual ICollection<Edificio> Edificios { get; set; }


}
}