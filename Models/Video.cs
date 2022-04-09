using System.ComponentModel.DataAnnotations;

namespace ChallengeAluraBackEnd.Models
{
    public class Video
    {
        public int Id { get; set; }

        [Required]
        public string? Titulo { get; set; }

        [Required]
        public string? Descricao { get; set; }

        [Required]
        public string? Url { get; set; }

    }
}