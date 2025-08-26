
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Project.Web.Api.Models
{
    public class Categoria_Jogos
    {
        [Key]
        public int ID { get; set; }
        public string Categoria { get; set; }
        public int JogoId { get; set; }
        public Jogos Jogos { get; set; }

        public Categoria_Jogos()
        {
            
        }

        public Categoria_Jogos(string categoria, int jogoId)
        {
            Categoria = categoria;
            JogoId = jogoId;
            
        }
    }
}
