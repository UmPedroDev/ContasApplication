namespace ContasApplication.Models
{
    public class DespesaAuxiliar
    {
        public List<DespesaModel>? ListDespesas { get; set; }
        public List<Etiquetas> Etiquetas { get; set; } = new List<Etiquetas>();
        public Mes? Mes { get; set; }
        public DateTime DataFiltro { get; set; }
        public double ValorTotal { get; set; }
    }
}
