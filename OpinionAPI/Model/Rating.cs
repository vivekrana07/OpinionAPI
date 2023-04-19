using OpinionAPI.Interface;
using System.ComponentModel.DataAnnotations;

namespace OpinionAPI.Model
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public int MovieRating { get; set; }
        public string? Comment { get; set; }
        public DateTime? CreatedOn { get; set; }

        public Users Users { get; set; }
        public Movies Movies { get; set; }
    }
}
