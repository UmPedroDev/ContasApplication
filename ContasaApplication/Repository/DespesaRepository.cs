using ContasApplication.Data;
using ContasApplication.Models;

namespace ContasApplication.Repository
{
    public class DespesaRepository : IDespesaRepository
    {
        private readonly BankContext _bankContext;
        public DespesaRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }



        public DespesaModel AddDespesa(DespesaModel despesa)
        {
            var newDespesa = new DespesaModel
            {
                NomeDespesa = despesa.NomeDespesa,
                ValorDespesa = despesa.ValorDespesa,
                CreateDate = DateTime.Now,
                Parcelado = despesa.Parcelado,
                QuantidadeParcelas = despesa.QuantidadeParcelas,
                QuantidadeParcelasPagas = despesa.QuantidadeParcelasPagas
            };

            if (despesa.Parcelado == Enums.EnumSimNao.Sim)
            {
                newDespesa.QuantidadeParcelas =- newDespesa.QuantidadeParcelasPagas;
            }
            _bankContext.Add(newDespesa);
            _bankContext.SaveChanges();
            return newDespesa;
        }

        public List<DespesaModel> FindAllDespesa()
        {
            var despesas = new List<DespesaModel>();
            foreach (var item in _bankContext.Despesas)
            {
                despesas.Add(item);
            }
            return despesas;
        }
    }
}
