using System.ComponentModel.DataAnnotations;

namespace Desafio.Domain.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Category { get; set; }
    }
}