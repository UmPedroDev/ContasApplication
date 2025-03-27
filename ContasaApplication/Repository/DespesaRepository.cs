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

        public DespesaModel AddDespesa(DespesaModel despesa)
        {
            Mes mesDespesa = VerificaSeExisteMesParcela(DateTime.Now);
            var despesas = new List<DespesaModel>();

            var newDespesa = new DespesaModel
            {
                NomeDespesa = despesa.NomeDespesa,
                ValorDespesa = despesa.ValorDespesa,
                Parcelado = despesa.Parcelado,
                QuantidadeParcelas = despesa.QuantidadeParcelas,
                QuantidadeParcelasPagas = despesa.QuantidadeParcelasPagas,
                CreateDate = DateTime.Now,
                MesReferencia = mesDespesa,
                MesFimParcelado = DateTime.Now.AddMonths(despesa.QuantidadeParcelas - despesa.QuantidadeParcelasPagas),
                DespesaFixa = despesa.DespesaFixa,
                Etiqueta = despesa.Etiqueta,
                UsuarioId = despesa.UsuarioId,
            };


            if (despesa.Parcelado == true)
            {
                var quantidadeParcelas = (despesa.QuantidadeParcelas - 1 + DateTime.Now.Month) - despesa.QuantidadeParcelasPagas;
                var dataSoma = DateTime.Now;
                var parcelasPagas = 0;

                for (int i = DateTime.Now.Month; i <= quantidadeParcelas; i++)
                {
                    var parcela = CriarParcelaDespesa(newDespesa);

                    dataSoma = !(parcela.QuantidadeParcelas > 0 && i == DateTime.Now.Month) ? dataSoma.AddMonths(1) : dataSoma;
                    parcela.CreateDate = parcela.QuantidadeParcelasPagas > 0 && i == DateTime.Now.Month ? DateTime.Now : dataSoma;
                    parcela.MesReferencia = VerificaSeExisteMesParcela(dataSoma);
                    parcela.QuantidadeParcelasPagas = parcelasPagas;
                    parcela.QuantidadeParcelas -= parcelasPagas;

                    _bankContext.Add(parcela);
                    _bankContext.SaveChanges();

                    parcelasPagas++;
                    despesas.Add(parcela);
                    AtualizarIdParcelado(despesas);
                }
                return newDespesa;
            }

            _bankContext.Add(newDespesa);
            _bankContext.SaveChanges();
            return newDespesa;
        }


        public DespesaModel CriarParcelaDespesa(DespesaModel despesa)
        {
            var newDespesa = new DespesaModel
            {
                NomeDespesa = despesa.NomeDespesa,
                ValorDespesa = despesa.ValorDespesa,
                Parcelado = despesa.Parcelado,
                QuantidadeParcelas = despesa.QuantidadeParcelas,
                QuantidadeParcelasPagas = despesa.QuantidadeParcelasPagas,
                MesReferencia = despesa.MesReferencia,
                MesFimParcelado = DateTime.Now.AddMonths(despesa.QuantidadeParcelas),
                DespesaFixa = false,
                UsuarioId = despesa.UsuarioId,
            };

            return newDespesa;
        }


        public void AtualizarIdParcelado(List<DespesaModel> despesas)
        {
            var id = despesas[0].Id;

            foreach (var item in despesas)
            {
                item.IdParcelado = id;
                _bankContext.Update(item);
                _bankContext.SaveChanges();
            }
        }

        public void RemoveDespesa(int id, int idUsuario)
        {
            var despesa = FindDespesaById(id, idUsuario);
            if (despesa.Parcelado == true)
            {
                _bankContext.RemoveRange(_bankContext.Despesas.Where(x => x.IdParcelado == id));
                _bankContext.SaveChanges();
            }
            else
            {
                _bankContext.Remove(FindDespesaById(id, idUsuario));
                _bankContext.SaveChanges();
            }
        }

        public DespesaModel FindDespesaById(int id, int idUsuario)
        {
            var despesa = _bankContext.Despesas.FirstOrDefault(x => x.Id == id && x.UsuarioId == idUsuario);
            return despesa;
        }

        public List<DespesaModel> FindAllDespesa(int idUsuario)
        {
            var despesas = new List<DespesaModel>();

            despesas = _bankContext.Despesas.Where(x => x.UsuarioId == idUsuario).ToList();

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
        public List<DespesaModel> FindDespesaMes(DateTime mesReferencia, int idUsuario)
        {
            List<DespesaModel> despesas = new List<DespesaModel>();

            foreach (var item in _bankContext.Despesas.Where(x => x.UsuarioId == idUsuario))
            {
                if (item.CreateDate.Month == mesReferencia.Month || item.DespesaFixa == true)
                {
                    despesas.Add(item);
                }
            }

            return despesas;
        }

        public List<Mes> FindAllMesDespesas()
        {
            return _bankContext.Mes.ToList();
        }
        public Etiquetas FindEtiquetas(int id)
        {
            return _bankContext.Etiquetas.FirstOrDefault(x => x.EtiquetaId == id);
        }

        public List<Etiquetas> FindAllEtiquetas()
        {
            return _bankContext.Etiquetas.ToList();
        }

    }
}
