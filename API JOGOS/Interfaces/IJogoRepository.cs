using Jogos_API.Controllers;
using Jogos_API.Domains;

namespace Jogos_API.Interfaces
{
   
        public interface IJogoRepository 
        {
            void Cadastrar(Jogo jogo);
            void Atualizar(Guid id, Jogo jogo);
            void Deletar(Guid id);
            List<Jogo> Listar();
        }
}


