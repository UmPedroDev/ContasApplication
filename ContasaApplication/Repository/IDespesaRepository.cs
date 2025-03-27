using ContasApplication.Models;

namespace ContasApplication.Repository
{
    public interface IDespesaRepository
    {
        public DespesaModel AddDespesa(DespesaModel despesa);
        public List<DespesaModel> FindAllDespesa(int idUsuario);
        public double GetValorTotalDespesa(List<DespesaModel> despesas);
        public List<DespesaModel> FindDespesaMes(DateTime mesReferencia, int idUsuario);
        public List<Mes> FindAllMesDespesas();
        public DespesaModel FindDespesaById(int id, int idUsuario);
        public void RemoveDespesa(int id, int idUsuario);
        public Mes VerificaSeExisteMesParcela(DateTime mesReferencia);
        public Etiquetas FindEtiquetas(int id);
        public List<Etiquetas> FindAllEtiquetas();
    }
}
