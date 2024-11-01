using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hackaton.Shared.Enties
{
    public class Hackatonn //evento
    {

        public int Id { get; set; }

        [Display(Name = "Nombre Evento")]
        [MaxLength(50, ErrorMessage = "El nombre del evento no puede tener más de 50 caracteres.")]
        [Required(ErrorMessage = "El campo nombre del evento es obligatorio")]
        public string NombreEvento { get; set; }


        [Display(Name = "Fecha inicio")]
        [Required(ErrorMessage = "Esta fecha es obligatoria")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaInicio { get; set; }

        [Display(Name = "Fecha fin")]
        [Required(ErrorMessage = "Esta fecha es obligatoria")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaFin { get; set; }


        [Display(Name = "Tema principal del evento")]
        [MaxLength(100, ErrorMessage = "El tema principal no puede tener más de 100 caracteres.")]
        [Required(ErrorMessage = "El campo tema principal es obligatorio")]
        public string Tema { get; set; }


        [Display(Name = "Nombre completo del organizador")]
        [MaxLength(50, ErrorMessage = "El nombre del organizador no puede tener más de 50 caracteres.")]
        [Required(ErrorMessage = "El campo nombre del organizador es obligatorio")]
        public string Organizador { get; set; }
        
        //Relacion uno a muchos
        [JsonIgnore]
        public ICollection<Equipo> Equipos { get; set; }

        [JsonIgnore]
        public ICollection<Premio> Premios { get; set; }
        
    }
}
