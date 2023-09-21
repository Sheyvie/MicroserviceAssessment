using SocialMedia_Post.Models;
using static Azure.Core.HttpHeader;

namespace SocialMedia_Post.Services.Iservices
{
    public interface IPostInterface
    {
        Task<IEnumerable<Post>> GetPostsAsync();

        Task<Post> GetPostByIdAsync(Guid id);

    

        Task<string> AddPostAsync(Post post);
        Task<string> UpdatePostAsync(Post post);
        Task<string> DeletePostAsync(Post post);

        Task<Post>LikePostAsync(Guid Id);

        Task<Post> UnLikePostAsync(Guid Id);
        Task <IEnumerable<Post>> GetPostsByTagAsync(string tag);
    }
}
 