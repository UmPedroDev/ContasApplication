using ContasApplication.Data;
using ContasApplication.Models;

namespace ContasApplication.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BankContext _bankContext;
        public UsuarioRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public bool LoginUsuario(Usuarios usuarioLogin)
        {
            bool loginResposta = false;
            var usuarioValidacao = _bankContext.Usuarios.Where(x => x.Usuario == usuarioLogin.Usuario).FirstOrDefault();

            if (usuarioValidacao.Senha == usuarioLogin.Senha)
            {
                loginResposta = true;
            }

            if (usuarioValidacao != null)
            {
                loginResposta = true;
            }

            return loginResposta;
        }

        public void RegistrarUsuario(Usuarios usuario)
        {
            var novoUsuario = new Usuarios
            {
                Usuario = usuario.Usuario,
                DataCadastro = DateTime.Now,
                Senha = usuario.Senha,
                Email = usuario.Email
            };
            _bankContext.Usuarios.Add(novoUsuario);
            _bankContext.SaveChanges();
        }

        public bool ValidarEmailLogin(string email)
        {
            var resposta = false;
            var resultadoPesquisa = _bankContext.Usuarios.ToList().Where(x => x.Email == email).FirstOrDefault();
            if (resultadoPesquisa != null)
            {
                resposta = true;
            }
            return resposta;
        }

        public bool ValidarLoginUsuario(string usuarioNome)
        {
            var resposta = false;
            var resultadoPesquisa = _bankContext.Usuarios.ToList().Where(x => x.Usuario == usuarioNome).FirstOrDefault();
            if (resultadoPesquisa != null)
            {
                resposta = true;
            }
            return resposta;
        }

        public int GetIdUsuarioPeloLogin(string usuario)
        {
            var usuarioId = _bankContext.Usuarios.Where(x => x.Usuario == usuario).FirstOrDefault();
            return usuarioId.Id;
        }
    }
}
