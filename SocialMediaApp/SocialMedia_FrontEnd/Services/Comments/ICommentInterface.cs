using SocialMedia_FrontEnd.Models;
using SocilaMedia_FrontEnd.Models.Comments;

namespace SocialMedia_FrontEnd.Services.Comments
{
    public interface ICommentInterface
    {
        Task<List<Comment>> GetCommentsAsync();

        Task<Comment> GetCommentByIdAsync(Guid id);
        Task<ResponseDto> AddCommentAsync(CommentRequestDto commentRequestDto);
        Task<ResponseDto> UpdateCommentAsync(Guid id ,CommentRequestDto commentRequestDto);
        Task<ResponseDto> DeleteCommentAsync(Guid id );
    }
}
