using System.ComponentModel.DataAnnotations;

namespace AFFIFA.Domain.Entities
{
    public class Equipe
    {
        public int Id { get; set; }
        [Required]
        public string? Nome { get; set; }
        [Required]
        [MaxLength(3)]
        public string? Abreviacao { get; set; }
    }
}
