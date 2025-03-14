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
            despesas.ValorTotal = _despesaRepository.GetValorTotalDespesa(despesas.ListDespesas);
            despesas.Etiquetas = _despesaRepository.FindAllEtiquetas();

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

        public IActionResult RemoveDespesaView()
        {
            var despesas = new DespesaAuxiliar();

            despesas.ListDespesas = _despesaRepository.FindDespesaMes(DateTime.Now);
            despesas.ValorTotal = _despesaRepository.GetValorTotalDespesa(despesas.ListDespesas);

            return View(despesas);
        }

        public IActionResult RemoveDespesa(int id)
        {
            var despesa = _despesaRepository.FindDespesaById(id);

            if (despesa.Parcelado == true)
            {
                return RedirectToAction("RemoveParceladoConfirm", despesa);
            }

            _despesaRepository.RemoveDespesa(id);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveParceladoConfirm(DespesaModel despesa)
        {
            return View(despesa);
        }

        public IActionResult RemoveParceladoConfirmMes(int id)
        {
            _despesaRepository.RemoveDespesa(id);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveParceladoConfirmTodos(int id)
        {
            _despesaRepository.RemoveDespesa(id);
            return RedirectToAction("Index");
        }
    }
}
