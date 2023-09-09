using SocialMedia_Post.Models.Dtos;

namespace SocialMedia_Post.Services.Iservices
{
    public interface ICommentInterface
    {
        Task<IEnumerable<CommentsDto>> GetCommentsAsync();
    }
}
