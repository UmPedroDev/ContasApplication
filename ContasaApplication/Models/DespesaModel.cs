using System.ComponentModel.DataAnnotations;
using ContasApplication.Enums;

namespace ContasApplication.Models
{
    public class DespesaModel
    {
        [Key]
        public int Id { get; set; }
        public string NomeDespesa { get; set; } = string.Empty;
        public double ValorDespesa { get; set; }
        public DateTime CreateDate { get; set; }
        public EnumSimNao Parcelado { get; set; } = EnumSimNao.Não;
        public int QuantidadeParcelas { get; set; }
        public int QuantidadeParcelasPagas { get; set; }
    }
}
