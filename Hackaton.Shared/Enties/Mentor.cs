using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Hackaton.Shared.Enties
{
    public class Mentor
    {
        public int Id { get; set; }

        [Display(Name = "Nombre Completo")]
        [MaxLength(50, ErrorMessage = "El nombre del mentor no puede sobrepasar 50 caracteres")]
        [Required(ErrorMessage = "El nombre del mentor es obligatorio")]
        public string Nombre { get; set; }


        [Display(Name = "Area de experiencia")]
        [MaxLength(30, ErrorMessage = "El area de experiencia no puede sobrepasar 30 caracteres")]
        [Required(ErrorMessage = "El area de experiencia es obligaria")]
        public string AreaExperiencia { get; set; }

        //Relacion con Equipo

        [JsonIgnore]

        public Equipo Equipos{ get; set; }
        public int? EquipoId { get; set; }

        //Relacion muchos
        [JsonIgnore]
        public ICollection<Evaluacion> Evaluaciones { get; set; }

       


    }
}

