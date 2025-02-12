using ContasApplication.Enums;
using ContasApplication.Models;
using ContasApplication.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContasApplication.Controllers
{
    public class DespesasController : Controller
    {
        private readonly IDespesaRepository _despesaRepository;
        public DespesasController(IDespesaRepository despesaRepository)
        {
            _despesaRepository = despesaRepository;
        }

        public IActionResult Index()
        {
            var despesas = new DespesaAuxiliar();

            despesas.ListDespesas = _despesaRepository.FindDespesaMes(DateTime.Now);
            despesas.valorTotal = _despesaRepository.GetValorTotalDespesa(despesas.ListDespesas);

            return View(despesas);
        }

        public IActionResult AddDespesa()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDespesa(DespesaModel despesa)
        {
            despesa.ValorDespesa = (double)despesa.ValorDespesa;

            if (despesa.NomeDespesa != "")
            {
                _despesaRepository.AddDespesa(despesa);
                return RedirectToAction("Index");
            }

            return View(despesa);
        }
    }
}
