using ContasApplication.Data;
using ContasApplication.Enums;
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

        public Mes VerificaSeExisteMesParcela(DateTime mesReferencia)
        {
            Mes mesDespesa = _bankContext.Mes.FirstOrDefault(x => x.MesReferencia.Month == mesReferencia.Month);

            if (mesDespesa == null)
            {
                var mes = (MesesEnum)mesReferencia.Month;

                mesDespesa = new Mes()
                {
                    NomeMes = mes.ToString(),
                    MesReferencia = mesReferencia
                };

                _bankContext.Mes.Add(mesDespesa);
                _bankContext.SaveChanges();
            }

            return mesDespesa;
        }

        public DespesaModel CriarParcelaDespesa(DespesaModel despesa, Mes mes)
        {
            var newDespesa = new DespesaModel
            {
                NomeDespesa = despesa.NomeDespesa,
                ValorDespesa = despesa.ValorDespesa,
                Parcelado = despesa.Parcelado,
                QuantidadeParcelas = despesa.QuantidadeParcelas,
                QuantidadeParcelasPagas = despesa.QuantidadeParcelasPagas,
                MesReferencia = mes,
                CreateDate = DateTime.Now.AddMonths(1),
                MesFimParcelado = DateTime.Now.AddMonths(despesa.QuantidadeParcelas),
            };

            return newDespesa;
        }

        public DespesaModel AddDespesa(DespesaModel despesa)
        {
            Mes mesDespesa = VerificaSeExisteMesParcela(DateTime.Now);

            var newDespesa = new DespesaModel
            {
                NomeDespesa = despesa.NomeDespesa,
                ValorDespesa = despesa.ValorDespesa,
                CreateDate = DateTime.Now,
                Parcelado = despesa.Parcelado,
                QuantidadeParcelas = despesa.QuantidadeParcelas,
                QuantidadeParcelasPagas = despesa.QuantidadeParcelasPagas,
                MesReferencia = mesDespesa,
                MesFimParcelado = DateTime.Now.AddMonths(despesa.QuantidadeParcelas),
            };

            if (despesa.Parcelado == true)
            {
                for (int i = newDespesa.MesReferencia.MesReferencia.Month; i < newDespesa.MesFimParcelado.Month; i++)
                {
                    var mes = _bankContext.Mes.FirstOrDefault(x => x.MesReferencia.Month == i + 1 && x.MesReferencia.Year <= newDespesa.MesFimParcelado.Year);

                    if (mes == null)
                    {
                        mes = VerificaSeExisteMesParcela(newDespesa.CreateDate.AddMonths(1));
                    }

                    newDespesa = CriarParcelaDespesa(newDespesa, mes);
                    if (i >= newDespesa.CreateDate.Month)
                    {
                        newDespesa.CreateDate = new DateTime(newDespesa.CreateDate.Year, i + 1, DateTime.Now.Day);
                    }

                    _bankContext.Add(newDespesa);
                    _bankContext.SaveChanges();
                }
                return newDespesa;
            }

            _bankContext.Add(newDespesa);
            _bankContext.SaveChanges();
            return newDespesa;
        }

        public void RemoveDespesa(int id)
        {
            _bankContext.Remove(FindDespesaById(id));
            _bankContext.SaveChanges();
        }

        public DespesaModel FindDespesaById(int id)
        {
            return _bankContext.Despesas.FirstOrDefault(x => x.Id == id);
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
                if (item.CreateDate.Month == mesReferencia.Month || item.MesFimParcelado.Month == mesReferencia.Month || item.DespesaFixa == true)
                {
                    despesas.Add(item);
                }
            }

            return despesas;
        }
    }
}
