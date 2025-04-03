using Jogos_API.Context;
using Jogos_API.Domains;
using Jogos_API.Interfaces;

namespace Jogos_API.Repositorys
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Jogo_Context _context;
        public UsuarioRepository()
        {
            _context = new Jogo_Context();
        }
        public void Atualizar(Guid id, Usuario usuario)
        {
            try
            {
                Usuario usuarioBuscado = _context.usuario.Find(id)!;

                if (usuarioBuscado != null)
                {
                    usuarioBuscado.Nome = usuario.Nome;
                    usuarioBuscado.Nickname = usuario.Nickname;
                }

                _context.usuario.Update(usuarioBuscado!);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.UsuarioID = Guid.NewGuid();

                _context.usuario.Add(usuario);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Deletar(Guid id)
        {
            try
            {
                Usuario usuario = _context.usuario.Find(id)!;

                if (usuario != null)
                {
                    _context.usuario.Remove(usuario);
                }
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<Usuario>Listar()
        {
            try
            {
                return _context.usuario.ToList();
            }
            catch (Exception)
            { 
                return new List<Usuario>();
            }
        }
    }
    
    
}
