using DAL;
using Model;
using System.Collections.Generic;

namespace BLL
{
    public class UsuarioBLL
    {
        public void Inserir()
        {
            Usuario usuario = new Usuario();
            usuario.NomeUsuario = "João";
            usuario.Senha = "asdf123";
            usuario.Ativo = true;

            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.Inserir(usuario);
        }
        public void Excluir()
        {

        }
        public void Alterar()
        {

        }
        public List<Usuario> Buscar()
        {
            return new List<Usuario>();
        }
    }
}