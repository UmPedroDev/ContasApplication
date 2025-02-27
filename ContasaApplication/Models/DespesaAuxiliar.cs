namespace ContasApplication.Models
{
    public class DespesaAuxiliar
    {
        public List<DespesaModel>? ListDespesas { get; set; }
        public List<Mes>? Meses { get; set; }
        public DateTime DataFiltro { get; set; }
        public double ValorTotal { get; set; }
    }
}
