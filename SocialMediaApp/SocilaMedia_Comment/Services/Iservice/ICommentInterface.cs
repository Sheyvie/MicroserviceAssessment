using SocilaMedia_Comment.Models;

namespace SocilaMedia_Comment.Services.Iservice
{
    public interface ICommentInterface
    {
        Task<IEnumerable<Comments>> GetCommentsAsync();

        Task<Comments> GetCommentByIdAsync(Guid id);


        Task<string> AddCommentAsync(Comments comment);
        Task<string> UpdateCommentAsync(Comments comment);
        Task<string> DeleteCommentAsync(Comments comment);
    }
}
