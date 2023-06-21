using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpinionAPI.Model
{
    public class Movies
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Image { get; set; }

        public byte[] ImageByte { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
