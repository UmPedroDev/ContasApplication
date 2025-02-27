using System.ComponentModel.DataAnnotations;

namespace ContasApplication.Models
{
    public class Mes
    {
        [Key]
        public int Id { get; set; }
        public string NomeMes { get; set; }
        public DateTime MesReferencia { get; set; }
        public double valorTotal { get; set; }
    }
}
