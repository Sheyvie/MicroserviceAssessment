using SocialMedia_Post.Models.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMedia_Post.Models
{
    public class Posts
    {
        [Key]
        public Guid PostId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        

        [NotMapped]
        public CommentsDto? Comments { get; set; }

        public string Tag { get; set; } = string.Empty;
       

        public DateTime DateCreated { get; set; }
       
    }
}
