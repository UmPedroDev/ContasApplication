namespace ContasApplication.Models
{
    public class DespesaAuxiliar
    {
        public List<DespesaModel> ListDespesas { get; set; }
        public DateTime DataFiltro { get; set; }
        public double valorTotal { get; set; }
    }
}
