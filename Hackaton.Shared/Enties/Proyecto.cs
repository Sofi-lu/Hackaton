    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hackaton.Shared.Enties
{
    public class Proyecto
    {
        public int Id { get; set; }

        [Display(Name = "Nombre Proyecto")]
        [MaxLength(20, ErrorMessage = "El nombre del proyecto no puede sobrepasar 20 caracteres")]
        [Required(ErrorMessage = "El nombre del proyecto es obligatorio")]
        public string Nombre { get; set; }


        [Display(Name = "Descripcion")]
        [MaxLength(100, ErrorMessage = "La descripcion del proyecto no puede sobrepasar 100 caracteres")]
        [Required(ErrorMessage = "La descripcion del proyecto es obligatorio")]
        public string Descripcion { get; set; }


        [Display(Name = "Estado del proyecto")]
        [RegularExpression("(?i)Progreso|Finalizado", ErrorMessage = "El estado debe ser 'Progreso' o 'Finalizado'")]
        [Required(ErrorMessage = "El estado del proyecto es un campo obligatorio")]
        public string Estado { get; set; }


        [Display(Name = "Fecha de entrega")]
        [Required(ErrorMessage = "La fecha de entrega es obligatoria")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaEntrega { get; set; }

        //Relacion muchos

        [JsonIgnore]
        public ICollection<Equipo> Equipos { get; set; }

      //  public Proyecto()
      //  {
      //      Equipos = new List<Equipo>();
     //   }

    }
}
