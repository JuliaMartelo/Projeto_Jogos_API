using System.Xml.Linq;
using Jogos_API.Context;
using Jogos_API.Domains;
using Jogos_API.Interfaces;

namespace Jogos_API.Repositorys
{
    public class JogoRepository : IJogoRepository
    {
        private readonly Jogo_Context _context;
        public JogoRepository(Jogo_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, Jogo jogo)
           
        {
            try
            {
                Jogo jogoBuscado = _context.jogo.Find(id)!;

                if (jogoBuscado != null)
                {
                    jogo.NomeDoJogo = jogo.NomeDoJogo;
                    jogo.Plataforma = jogo.Plataforma;
                }

                _context.jogo.Update(jogo);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Cadastrar(Jogo jogo)
        {
            try
            {
                _context.jogo.Add(jogo);
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
                Jogo jogoBuscado = _context.jogo.Find(id)!;

                if (jogoBuscado != null)
                {
                    _context.jogo.Remove(jogoBuscado);
                }
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Jogo> Listar()
        {
            try
            {
                return _context.jogo.Select(e => new Jogo
                {
                    JogoID = e.JogoID,
                    NomeDoJogo = e.NomeDoJogo,
                    Plataforma = e.Plataforma
                }).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}

