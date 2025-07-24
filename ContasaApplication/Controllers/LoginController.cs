using ContasApplication.Models;
using ContasApplication.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ContasApplication.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IActionResult> Index()
        {
            await LogoutUsuario();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RotaLoginRegistroAsync(Usuarios usuarios)
        {
            usuarios.Id = _usuarioRepository.GetIdUsuarioPeloLogin(usuarios.Usuario);

            if (usuarios == null)
            {
                TempData["MostrarModal"] = "True";
                TempData["MensagemErro"] = "Usuário não informado.";
                return View("Index");
            }
            bool verificacao = false;
            if (usuarios.Page == Enums.PageEnum.Login)
            {
                if (string.IsNullOrEmpty(usuarios.Usuario))
                {
                    TempData["MostrarModal"] = "True";
                    TempData["MensagemErro"] = "É obrigatório informar o usuário.";
                    return View("Index");
                }
                if (string.IsNullOrEmpty(usuarios.Senha))
                {
                    TempData["MostrarModal"] = "True";
                    TempData["MensagemErro"] = "A senha é obrigatória!";
                    return View("Index");
                }

                verificacao = _usuarioRepository.LoginUsuario(usuarios);
                if (verificacao == false)
                {
                    TempData["MostrarModal"] = "True";
                    TempData["MensagemErro"] = "Usuário ou senha inválidos.";
                    return View("Index");
                }
            }
            else
            {
                var validacaoRegistroUsuarioNome = _usuarioRepository.ValidarLoginUsuario(usuarios.Usuario);
                var validacaoRegistroUsuarioEmail = false;
                if (usuarios.Email != null)
                {
                    validacaoRegistroUsuarioEmail = _usuarioRepository.ValidarLoginUsuario(usuarios.Email);
                }
                if (string.IsNullOrEmpty(usuarios.Usuario))
                {
                    TempData["MostrarModal"] = "True";
                    TempData["MensagemErro"] = "É obrigatório informar o usuário.";
                    return View("Index");
                }
                if (validacaoRegistroUsuarioNome == true)
                {
                    TempData["MostrarModal"] = "True";
                    TempData["MensagemErro"] = "Já existe um usuário com este nome.";
                    return View("Index");
                }
                if (validacaoRegistroUsuarioEmail == true)
                {
                    TempData["MostrarModal"] = "True";
                    TempData["MensagemErro"] = "Já existe um usuário com este endereço de email.";
                    return View("Index");
                }
                if (string.IsNullOrEmpty(usuarios.Email))
                {
                    TempData["MostrarModal"] = "True";
                    TempData["MensagemErro"] = "Informe um email válido.";
                    return View("Index");
                }
                if (string.IsNullOrEmpty(usuarios.Senha))
                {
                    TempData["MostrarModal"] = "True";
                    TempData["MensagemErro"] = "A senha é obrigatória!";
                    return View("Index");
                }
                _usuarioRepository.RegistrarUsuario(usuarios);
            }

            if (verificacao == false)
            {
                return RedirectToAction("Index");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuarios.Usuario)
            };

            var identity = new ClaimsIdentity(claims, "CookieAuth");
            var principal = new ClaimsPrincipal(identity);

            HttpContext.Session.SetInt32("UsuarioId", usuarios.Id);
            await HttpContext.SignInAsync("CookieAuth", principal);

            return RedirectToAction("Index", "Despesas");

        }

        [HttpPost]
        public async Task<IActionResult> LogoutUsuario()
        {
            await HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction("Index", "Login");
        }
    }
}
