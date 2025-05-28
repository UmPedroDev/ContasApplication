using System.ComponentModel.DataAnnotations;
using ContasApplication.Enums;

namespace ContasApplication.Models
{
    public class Etiquetas
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Icone { get; set; } 
        public int EtiquetaId { get; set; }
    }
}
