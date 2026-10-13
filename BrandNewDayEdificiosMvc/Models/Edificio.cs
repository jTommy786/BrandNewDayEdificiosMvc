using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BrandNewDayEdificiosMvc.Models
{
    public class Edificio
    {
        [Key]
        public int EdificioId { get; set; }

        [Required(ErrorMessage = "El nombre del edificio es obligatorio.")]
        [StringLength(60, ErrorMessage = "El nombre no puede superar los 60 caracteres.")]
        [Display(Name = "Nombre del Edificio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El nivel de peligro es obligatorio.")]
        [Range(1, 7, ErrorMessage = "El peligro debe ser un número entero entre 1 y 7.")]
        [Display(Name = "Nivel de Peligro")]
        public int Peligro { get; set; }

        [Display(Name = "Vigilante asignado")]
        public string Vigilante { get; set; }

        // Clave Foránea
        [Required(ErrorMessage = "Debe asignar un barrio al edificio.")]
        [Display(Name = "Barrio")]
        public int BarrioId { get; set; }

        [ForeignKey("BarrioId")]
        public virtual Barrio Barrio { get; set; }
    }
}