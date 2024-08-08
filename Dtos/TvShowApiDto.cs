using System.ComponentModel.DataAnnotations;

namespace TvShowApi.Dtos
{
    public class TvShowApiDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The name must be less than 100 characters.")]
        public string Name { get; set; }

        public bool Favorite { get; set; }
    }
}
