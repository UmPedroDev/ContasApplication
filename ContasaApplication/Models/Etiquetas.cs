using System.ComponentModel.DataAnnotations;
using ContasApplication.Enums;

namespace ContasApplication.Models
{
    public class Etiquetas
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Icone { get; set; } = string.Empty;
        public int EtiquetaId { get; set; }
    }
}
