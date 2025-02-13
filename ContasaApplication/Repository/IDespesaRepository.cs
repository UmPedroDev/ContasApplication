using ContasApplication.Models;

namespace ContasApplication.Repository
{
    public interface IDespesaRepository
    {
        public DespesaModel AddDespesa(DespesaModel despesa);
        public List<DespesaModel> FindAllDespesa();
        public double GetValorTotalDespesa(List<DespesaModel> despesas);
        public List<DespesaModel> FindDespesaMes(DateTime mesReferencia);
        public DespesaModel FindDespesaById(int id);
        public void RemoveDespesa(int id);
    }
}
