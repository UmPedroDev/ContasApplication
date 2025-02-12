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

            if (despesa.Parcelado == true)
            {
                newDespesa.QuantidadeParcelas -= newDespesa.QuantidadeParcelasPagas;
                newDespesa.MesFimParcelado = DateTime.Now.AddMonths(newDespesa.QuantidadeParcelas);
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

        public double GetValorTotalDespesa(List<DespesaModel> despesas)
        {
            var valorTotal = 0.0;

            foreach (var item in despesas)
            {
                valorTotal += item.ValorDespesa;
            }
            return valorTotal;
        }
        public List<DespesaModel> FindDespesaMes(DateTime mesReferencia)
        {
            List<DespesaModel> despesas = new List<DespesaModel>();

            foreach (var item in _bankContext.Despesas)
            {
                if (item.CreateDate.Month == mesReferencia.Month || item.MesFimParcelado.Month > mesReferencia.Month || item.DespesaFixa == true)
                {
                    despesas.Add(item);
                }
            }

            return despesas;
        }
    }
}
