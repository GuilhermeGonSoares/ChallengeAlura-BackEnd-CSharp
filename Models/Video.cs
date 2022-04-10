using System.ComponentModel.DataAnnotations;

namespace ChallengeAluraBackEnd.Models
{
    public class Video
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]        
        public string? Titulo { get; set; }

        [Required]
        [MaxLength(300)]
        public string? Descricao { get; set; }

        [Required]
        [MaxLength(200)]        
        public string? Url { get; set; }

    }
}