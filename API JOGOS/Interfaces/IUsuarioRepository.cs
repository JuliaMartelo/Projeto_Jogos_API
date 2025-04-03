using Jogos_API.Domains;

namespace Jogos_API.Interfaces
{

        public interface IUsuarioRepository
        {
            void Cadastrar(Usuario usuario);
            void Atualizar(Guid id, Usuario usuario);
            void Deletar(Guid id);
            List<Usuario> Listar();

        }
}

