namespace SocialMedia_Post.Models.Dtos
{
    public class PostRequestDto
    {
        public Guid UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Tag { get; set; }= string.Empty;
        public DateTime DateCreated { get; set; }
        public int Likes { get; set; }
        public int UnLike { get; set; }

    }
}
