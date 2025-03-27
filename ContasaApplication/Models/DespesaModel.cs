using System.ComponentModel.DataAnnotations;

namespace ContasApplication.Models
{
    public class DespesaModel
    {
        [Key]
        public int Id { get; set; }
        public string NomeDespesa { get; set; }
        public double ValorDespesa { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Parcelado { get; set; }
        public int QuantidadeParcelas { get; set; }
        public int QuantidadeParcelasPagas { get; set; }
        public DateTime MesFimParcelado { get; set; }
        public bool DespesaFixa { get; set; }
        public int IdParcelado { get; set; }
        public Mes? MesReferencia { get; set; }
        public int Etiqueta { get; set; }
        public int UsuarioId { get; set; }
    }
}
