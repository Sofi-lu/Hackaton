using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hackaton.Shared.Enties
{
    public class Evaluacion
    {
        public int Id { get; set; }

        [Display(Name = "Puntuacion con respecto a la innovacion")]
        [Required(ErrorMessage = "La puntuacion es obligatoria")]
        public int PuntuacionInnovacion { get; set; }

        [Display(Name = "Puntuacion con respecto a la funcionalidad")]
        [Required(ErrorMessage = "La puntuacion es obligatoria")]
        public int PuntuacionFuncionalidad { get; set; }

        [Display(Name = "Puntuacion con respecto a la presentacion")]
        [Required(ErrorMessage = "La puntuacion es obligatoria")]
        public int PuntuacionPresentacion { get; set; }

        [Display(Name = "Comentarios")]
        [DataType(DataType.MultilineText)]
        public string Comentario { get; set; }

        //Relacion con Mentor
        
        [JsonIgnore]

        public Mentor Mentores { get; set; }
        public int MentorId { get; set; }

        //Relacion con Proyecto

        [JsonIgnore]
        public Proyecto Proyectos { get; set; }
        public int ProyectoId { get; set; }
        
    }
}