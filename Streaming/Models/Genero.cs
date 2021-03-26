using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Streaming.Models
{
    public class Genero
    {
        public int Id { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "A descrição é obrigatória .")]
        public string Descricao { get; set; }
        public List<Filmes> Filmes { get; set; }
        public List<Series> Series { get; set; }

    }
}
