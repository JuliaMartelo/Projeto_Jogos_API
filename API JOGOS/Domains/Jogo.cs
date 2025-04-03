
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Jogos_API.Domains
{
    [Table("Jogo")]
    //O Index faz com que o nome do jogo seja unico
    [Index(nameof(NomeDoJogo), IsUnique = true)]

    //Public class -> Cria uma classe publica
    public class Jogo
    {
        //Preencher os atributos
        [Key]
        public Guid JogoID { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        //O required faz com que o nome do jogo seja obrigatorio
        [Required(ErrorMessage = "O nome do jogo e obrigatorio!")]
        public string? NomeDoJogo { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string? Plataforma { get; set; }
    }
}
