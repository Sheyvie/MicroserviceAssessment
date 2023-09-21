using SocilaMedia_Comment.Models;

namespace SocilaMedia_Comment.Services.Iservice
{
    public interface ICommentInterface
    {
        Task<IEnumerable<Comment>> GetCommentsAsync();

        Task<Comment> GetCommentByIdAsync(Guid id);


        Task<string> AddCommentAsync(Comment comment);
        Task<string> UpdateCommentAsync(Comment comment);
        Task<string> DeleteCommentAsync(Comment comment);
    }
}
