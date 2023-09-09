using AutoMapper;
using SocilaMedia_Comment.Models;
using SocilaMedia_Comment.Models.Dtos;

namespace SocilaMedia_Comment.Profiles
{
    public class CommentProfile:Profile
    {
        public CommentProfile()
        {
            CreateMap<CommentRequestDto, Comments>().ReverseMap();
        }
    }
}
