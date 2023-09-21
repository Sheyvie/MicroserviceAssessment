using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialMedia_Comment.Data;
using SocilaMedia_Comment.Models;
using SocilaMedia_Comment.Models.Dtos;
using SocilaMedia_Comment.Services.Iservice;

namespace SocilaMedia_Comment.Services
{
    public class CommentService:ICommentInterface
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ResponseDto _responseDto;

        public CommentService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _responseDto = new ResponseDto();
        }
        public async Task<string> AddCommentAsync(Comment comment)
        {
            _context.Add(comment);
            await _context.SaveChangesAsync();
            return "Comment Added Successfully";
        }

        public async Task<string> DeleteCommentAsync(Comment comment)
        {
            _context.Remove(comment);
            await _context.SaveChangesAsync();
            return "Comment Removed Successfully";
        }

        public async Task<Comment> GetCommentByIdAsync(Guid id)
        {
            return await _context.Comments.FirstOrDefaultAsync(x => x.CommentId == id);
        }

      
        public async Task<IEnumerable<Comment>> GetCommentsAsync()
        {
            return await _context.Comments.ToListAsync();
        }


        public async Task<string> UpdateCommentAsync(Comment comment)
        {
            _context.Update(comment);
            await _context.SaveChangesAsync();
            return "Comment Updated Successfully";
        }
    }

}

