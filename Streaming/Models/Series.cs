using System;
using System.ComponentModel.DataAnnotations;

namespace Streaming.Models
{
    public class Series
    {
        public int Id { get; set; }
        [Display(Name = "Título")]
        [Required(ErrorMessage = "O título é obrigatório.")]
        public string Titulo { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Data de lançamento é obrigatória.")]
        [Display(Name = "Lançamento")]
        [DataType(DataType.Date)]
        public DateTime Lancamento { get; set; }
        public bool Ativo { get; set; }
        [Display(Name = "Gênero")]
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }
    }
    
}
