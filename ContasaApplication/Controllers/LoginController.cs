using ContasApplication.Models;
using ContasApplication.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContasApplication.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RotaLoginRegistro(Usuarios usuarios)
        {
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
            var idUsuario = _usuarioRepository.GetIdUsuarioPeloLogin(usuarios.Usuario);
            HttpContext.Session.SetInt32("UsuarioId", idUsuario);
            return RedirectToAction("Index", "Despesas");
        }
    }
}
