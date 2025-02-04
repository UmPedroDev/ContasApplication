using Microsoft.AspNetCore.Mvc;

namespace ContasApplication.Controllers
{
    public class DespesasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddDespesaView()
        {
            return View();
        }
    }
}
