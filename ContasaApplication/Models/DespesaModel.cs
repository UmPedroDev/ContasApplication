using System.ComponentModel.DataAnnotations;
using ContasApplication.Enums;

namespace ContasApplication.Models
{
    public class DespesaModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o nome da despesa")]
        public string NomeDespesa { get; set; } = string.Empty;
        [Required(ErrorMessage = "Informe o valor da despesa")]
        public double ValorDespesa { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Parcelado { get; set; }
        public int QuantidadeParcelas { get; set; }
        public int QuantidadeParcelasPagas { get; set; }
        public bool DespesaFixa { get; set; }
        public DateTime MesFimParcelado { get; set; }
    }
}
