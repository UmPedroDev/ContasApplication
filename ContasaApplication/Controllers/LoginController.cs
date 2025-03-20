using Microsoft.AspNetCore.Mvc;

namespace ContasApplication.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
