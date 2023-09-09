namespace SocialMedia_Post.Models.Dtos
{
    public class PostRequestDto
    {
        public Guid UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Tage { get; set; }= string.Empty;
        public DateTime DateCreated { get; set; }
        
    }
}
