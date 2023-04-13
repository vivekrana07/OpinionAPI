using System.ComponentModel.DataAnnotations;

namespace OpinionAPI.Model
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required] 
        public string Name { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
        public DateTime Created { get; set; }

        public ICollection<Rating> Ratings { get; set; }
    }
}
