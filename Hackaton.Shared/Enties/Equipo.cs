using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hackaton.Shared.Enties
{
    public class Equipo
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del equipo")]
        [MaxLength(20, ErrorMessage = "El nombre del equipo no puede tener más de 20 caracteres.")]
        [Required(ErrorMessage = "El campo nombre del equpo es obligatorio")]
        public string NombreEquipo { get; set; }



        [Display(Name = "Cantidad de Miembros")]
        [Range(1, 10, ErrorMessage = "La cantidad de miembros debe estar entre 1 y 10.")]
        public int CantidadMiembros { get; set; }


        [Display(Name = "Experiencia")]
        [Required(ErrorMessage = "El campo experiencia es obligatorio.")]
        [RegularExpression("(?i)desarrollo|diseño|gestion", ErrorMessage = "La experiencia debe ser 'desarrollo', 'diseño' o 'gestión'.")]
        public string Experiencia { get; set; }
        
        //Relacion con hakaton

        [JsonIgnore]
        public Hackatonn Hackatones { get; set; }
        public int HackatonnId {  get; set; }


        //relacion con Proyecto

        [JsonIgnore]
        public Proyecto Proyectos { get; set; }
        public int ProyectoId { get; set; }

        //Relacion uno a muchos
        [JsonIgnore]
        public ICollection<Participante> Participantes { get; set; }

        [JsonIgnore]
        public ICollection<Mentor> Mentores { get; set; }
        


    }
}
