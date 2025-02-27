using ContasApplication.Models;
using ContasApplication.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContasApplication.Controllers
{
    public class ProjecaoController : Controller
    {
        private readonly IDespesaRepository _despesaRepository;
        public ProjecaoController(IDespesaRepository despesaRepository)
        {
            _despesaRepository = despesaRepository;
        }

        public IActionResult Index()
        {
            var mesesComDespesa = _despesaRepository.FindAllMesDespesas();
            var despesas = _despesaRepository.FindAllDespesa();
            var despesaAuxilar = new DespesaAuxiliar();
            despesaAuxilar.Meses = new List<Mes>();
            despesaAuxilar.ListDespesas = new List<DespesaModel>();

            foreach (var item in mesesComDespesa)
            {
                foreach (var item2 in despesas)
                {
                    if (item2.CreateDate.Month == item.MesReferencia.Month || item2.DespesaFixa == true)
                    {
                        bool existeMes = despesaAuxilar.Meses.FirstOrDefault(x => x.MesReferencia.Month == item.MesReferencia.Month) == null? false : true;
                        if (existeMes)
                        {
                            item.valorTotal += item2.ValorDespesa;
                            despesaAuxilar.ListDespesas.Add(item2);
                            continue;
                        }

                        item.valorTotal += item2.ValorDespesa;
                        despesaAuxilar.Meses.Add(item);
                        despesaAuxilar.ListDespesas.Add(item2);
                    }
                }
            }

            return View(despesaAuxilar);
        }
    }
}
