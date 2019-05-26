using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AirPlaneCrudTeste.Models
{
    public class AirPlane
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Column(TypeName= "nvarchar(100)")]
        public string modelo{ get; set; }
        [Required]
        public int qtdPassageiros { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime dtaCriacao { get; set; }
    }
}
