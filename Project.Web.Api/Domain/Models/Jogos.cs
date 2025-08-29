using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Project.Web.Api.Domain.Models
{
    public class Jogos
    {
        [Key]
        public int ID_Jogo { get; set; }
        public string Nome { get; set; }
        [JsonIgnore]
        public ICollection<Categoria_Jogos> Categoria { get; set; } = new List<Categoria_Jogos>();
        public Jogos() { }

        public Jogos(string nome)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
          
        }
    }
}
