using AutoMapper;
using SocialMedia_Post.Models;
using SocialMedia_Post.Models.Dtos;

namespace SocialMedia_Post.Profiles
{
    public class PostProfile:Profile
    {
        public PostProfile()
        {
            CreateMap<PostRequestDto, Post>().ReverseMap();
        }
    }
}
