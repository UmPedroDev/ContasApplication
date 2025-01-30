using ContasApplication.Enums;

namespace ContasApplication.Models
{
    public class DespesaModel
    {
        public string NomeDespesa { get; set; } = string.Empty;
        public double ValorDespesa { get; set; }
        public DateTime CreateDate { get; set; }
        public EnumSimNao Parcelado { get; set; } = EnumSimNao.Não;
        public int QuantidadeParcelas { get; set; }
        public int QuantidadeParcelasPagas { get; set; }
    }
}
