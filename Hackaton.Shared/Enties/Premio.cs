using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hackaton.Shared.Enties
{
    public class Premio
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del premio")]
        [MaxLength(30, ErrorMessage = "El nombre del premio no puedo exceder 30 caracteres")]
        [Required(ErrorMessage = "El nombre del premio es obligarotio")]
        public string Nombre { get; set; }

        [Display(Name = "Descripcion")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        

        // Relacion con hackaton
        [JsonIgnore]
        public Hackatonn Hackatonn { get; set; }
        public int HackatonnId { get; set; }

        // Relación con el equipo ganador
        [JsonIgnore]
        public Equipo Equipo { get; set; }
        public int? EquipoId { get; set; }


    }
}

