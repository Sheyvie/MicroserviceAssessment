using SocialMedia_FrontEnd.Models;
using SocialMedia_FrontEnd.Models.Posts;

namespace SocialMedia_FrontEnd.Services.Posts
{
    public interface IPostInterface
    {
        Task<List<Post>> GetPostsAsync();

        Task<Post> GetPostByIdAsync(Guid id);
        Task<ResponseDto> AddPostAsync(PostRequestDto postRequestDto);
        Task<ResponseDto> DeletePostAsync(Guid id);
        Task<ResponseDto> UpdatePostAsync(Guid id, PostRequestDto postRequestDto);

        Task<Post> LikePostAsync(Guid id);
        Task<Post> UnLikePostAsync(Guid id);
        Task<Post> GetPostByTagAsync();


    }
}
