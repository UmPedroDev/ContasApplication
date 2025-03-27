using System.Globalization;
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
            var idUsuario = HttpContext.Session.GetInt32("UsuarioId") ?? 0;

            despesas.ListDespesas = _despesaRepository.FindDespesaMes(DateTime.Now, idUsuario);
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
            despesa.UsuarioId = HttpContext.Session.GetInt32("UsuarioId") ?? 0;
            despesa.ValorDespesa = Convert.ToDouble(despesa.ValorDespesa.ToString().Replace(",", "."), CultureInfo.InvariantCulture);

            if (despesa.NomeDespesa != "")
            {
                _despesaRepository.AddDespesa(despesa);
                return RedirectToAction("Index");
            }

            return View(despesa);
        }

        public IActionResult RemoveDespesaView()
        {
            int idUsuario = HttpContext.Session.GetInt32("UsuarioId")?? 0;
            var despesas = new DespesaAuxiliar();

            despesas.ListDespesas = _despesaRepository.FindDespesaMes(DateTime.Now, idUsuario);
            despesas.ValorTotal = _despesaRepository.GetValorTotalDespesa(despesas.ListDespesas);

            return View(despesas);
        }

        public IActionResult RemoveDespesa(int id)
        {
            int idUsuario = HttpContext.Session.GetInt32("UsuarioId") ?? 0;

            var despesa = _despesaRepository.FindDespesaById(id, idUsuario);

            if (despesa.Parcelado == true)
            {
                return RedirectToAction("RemoveParceladoConfirm", despesa);
            }

            _despesaRepository.RemoveDespesa(id, idUsuario);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveParceladoConfirm(DespesaModel despesa)
        {
            return View(despesa);
        }

        public IActionResult RemoveParceladoConfirmMes(int id)
        {
            int idUsuario = HttpContext.Session.GetInt32("UsuarioId") ?? 0;

            _despesaRepository.RemoveDespesa(id, idUsuario);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveParceladoConfirmTodos(int id)
        {
            int idUsuario = HttpContext.Session.GetInt32("UsuarioId") ?? 0;

            _despesaRepository.RemoveDespesa(id, idUsuario);
            return RedirectToAction("Index");
        }
    }
}
