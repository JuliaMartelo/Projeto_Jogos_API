using Jogos_API.Domains;
using Microsoft.EntityFrameworkCore;

namespace Jogos_API.Context
{
    public class Jogo_Context : DbContext
    {
        public Jogo_Context()
        { 
        
        }
        public Jogo_Context(DbContextOptions<Jogo_Context> options) : base(options)
        { 
        
        }

        public DbSet<Jogo> Jogo { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-VINIDR3; Database=Jogos; User Id = sa; Pwd = Senai@134;TrustServerCertificate=true;");
            }
        }
    }
}
