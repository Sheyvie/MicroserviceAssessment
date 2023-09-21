using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialMedia_Post.Data;
using SocialMedia_Post.Models;
using SocialMedia_Post.Models.Dtos;
using SocialMedia_Post.Services.Iservices;
using System.Linq;
using static Azure.Core.HttpHeader;

namespace SocialMedia_Post.Services
{
    public class PostService : IPostInterface
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ResponseDto _responseDto;

        public PostService( AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _responseDto = new ResponseDto();
        }
        public async Task<string> AddPostAsync(Post post)
        {
            _context.Add(post);
            await _context.SaveChangesAsync();
            return "Post Added Successfully";
        }

        public async Task<string> DeletePostAsync(Post post)
        {
            _context.Remove(post);
            await _context.SaveChangesAsync();
            return "Post Removed Successfully";
        }

        public async Task<Post> GetPostByIdAsync(Guid id)
        {
            return await _context.Posts.FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetPostsByTagAsync(string tag)
        {
            throw new NotImplementedException();
        }
    

        public async Task<Post> LikePostAsync(Guid Id)
        {
            return await _context.Posts.FirstOrDefaultAsync(x => x.PostId == Id);
        }

        public async Task<Post> UnLikePostAsync(Guid Id)
        {
            return await _context.Posts.FirstOrDefaultAsync(x => x.PostId == Id);
        }

        public async Task<string> UpdatePostAsync(Post post)
        {
            _context.Update(post);
            await _context.SaveChangesAsync();
            return "Post Updated Successfully";
        }

       
    }
}
