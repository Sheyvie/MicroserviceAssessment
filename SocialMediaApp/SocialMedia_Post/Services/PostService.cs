using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialMedia_Post.Data;
using SocialMedia_Post.Models;
using SocialMedia_Post.Models.Dtos;
using SocialMedia_Post.Services.Iservices;
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
        public async Task<string> AddPostAsync(Posts post)
        {
            _context.Add(post);
            await _context.SaveChangesAsync();
            return "Post Added Successfully";
        }

        public async Task<string> DeletePostAsync(Posts post)
        {
            _context.Remove(post);
            await _context.SaveChangesAsync();
            return "Post Removed Successfully";
        }

        public async Task<Posts> GetPostByIdAsync(Guid id)
        {
            return await _context.Posts.FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task<IEnumerable<Posts>> GetPostsAsync()
        {
            return await _context.Posts.ToListAsync();
        }
    

        public async Task<string> UpdatePostAsync(Posts post)
        {
            _context.Update(post);
            await _context.SaveChangesAsync();
            return "Post Updated Successfully";
        }
    }
}
