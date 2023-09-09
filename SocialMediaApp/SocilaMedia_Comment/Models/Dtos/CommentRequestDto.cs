namespace SocilaMedia_Comment.Models.Dtos
{
    public class CommentRequestDto
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public string Body { get; set; } = string.Empty;
    }
}
