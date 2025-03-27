using ContasApplication.Models;

namespace ContasApplication.Repository
{
    public interface IUsuarioRepository
    {
        public void RegistrarUsuario(Usuarios usuario);
        public bool LoginUsuario(Usuarios usuario);
        public bool ValidarLoginUsuario(string usuarioNome);
        public bool ValidarEmailLogin(string email);
        public int GetIdUsuarioPeloLogin(string usuario);
    }
}
