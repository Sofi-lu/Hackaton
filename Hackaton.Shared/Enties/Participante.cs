using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hackaton.Shared.Enties
{
    public  class Participante
    {
        public int Id { get; set; }


        [Display(Name = "Nombre completo")]
        [MaxLength(50, ErrorMessage ="El nombre no puedo exceder 50 caracteres")]
        [Required(ErrorMessage ="El nombre es obligarotio")]
        public string Nombre { get; set; }


        [Display (Name="Rol")]
        [RegularExpression("(?i) desarrollador|Diseñador|Lider|", ErrorMessage ="El rol debe ser Desarrollador, Diseñador o Lider")]
        [Required(ErrorMessage= "El campo RoL es obligatorio")]
        public string Rol { get; set; }

        [Display(Name = "Experiencia")]
        [Required(ErrorMessage = "El campo experiencia es obligatorio.")]
        [RegularExpression("(?i)desarrollo|diseño|gestion", ErrorMessage = "La experiencia debe ser 'desarrollo', 'diseño' o 'gestión'.")]
        public string Experiencia { get; set; }

        //Relacion con Equipo

        [JsonIgnore]

        public Equipo Equipos { get; set; }
        public int? EquipoId { get; set; }
    }
}
