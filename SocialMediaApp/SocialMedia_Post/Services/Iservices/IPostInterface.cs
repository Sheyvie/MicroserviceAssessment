using SocialMedia_Post.Models;
using static Azure.Core.HttpHeader;

namespace SocialMedia_Post.Services.Iservices
{
    public interface IPostInterface
    {
        Task<IEnumerable<Posts>> GetPostsAsync();

        Task<Posts> GetPostByIdAsync(Guid id);

    

        Task<string> AddPostAsync(Posts post);
        Task<string> UpdatePostAsync(Posts post);
        Task<string> DeletePostAsync(Posts post);
    }
}
 