using System.ComponentModel.DataAnnotations;
using ContasApplication.Enums;

namespace ContasApplication.Models
{
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string? Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataCriacao { get; set; }
        public PageEnum? Page { get; set; }
    }
}
