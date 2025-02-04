using ContasApplication.Models;

namespace ContasApplication.Repository
{
    public interface IDespesaRepository
    {
        public DespesaModel AddDespesa(DespesaModel despesa);
        public List<DespesaModel> FindAllDespesa();
    }
}
