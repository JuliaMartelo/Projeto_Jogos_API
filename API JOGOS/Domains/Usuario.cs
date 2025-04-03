using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Jogos_API.Domains
{
    [Table("Usuario")]
    [Index(nameof(Nickname), IsUnique = true)]
    //Public class -> Cria uma classe publica
    public class Usuario
    {
        [Key]
        public Guid UsuarioID { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome do usuario e obrigatorio!")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O Nickname e obrigatorio!")]
        public string? Nickname { get; set; }

        public Guid JogoID { get; set; }
        [ForeignKey("JogoID")]
        public Jogo? jogo { get; set; }
    }
}
