using System.ComponentModel.DataAnnotations;

namespace SocialMedia_Post.Models.Dtos
{
    public class CommentsDto
    {
        
        public Guid CommentId { get; set; }
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        
    }
}
