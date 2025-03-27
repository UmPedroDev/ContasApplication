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
            int idUsuario = HttpContext.Session.GetInt32("UsuarioId") ?? 0;

            var despesaAuxiliarLista = new List<DespesaAuxiliar>();
            var mesesComDespesa = _despesaRepository.FindAllMesDespesas();
            var despesas = _despesaRepository.FindAllDespesa(idUsuario);

            foreach (var mes in mesesComDespesa)
            {
                var despesaAuxiliar = new DespesaAuxiliar();
                despesaAuxiliar.Mes = mes;
                despesaAuxiliar.ListDespesas = new List<DespesaModel>();
                despesaAuxiliar.Etiquetas = _despesaRepository.FindAllEtiquetas();

                foreach (var despesa in despesas)
                {
                    if (despesa.CreateDate.Month == mes.MesReferencia.Month || despesa.DespesaFixa == true)
                    {
                        despesaAuxiliar.ListDespesas.Add(despesa);
                        despesaAuxiliar.ValorTotal += despesa.ValorDespesa;
                    }
                }

                despesaAuxiliarLista.Add(despesaAuxiliar);
            }

            return View(despesaAuxiliarLista);
        }
    }
}
