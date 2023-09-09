using AutoMapper;
using SocialMedia_Auth.Models;
using SocialMedia_Auth.Models.Dtos;

namespace SocialMedia_Auth.Profiles
{
    public class AuthProfiles: Profile
    {
        public AuthProfiles()
        {
            CreateMap<RegisterRequestDto, AppUser>()
            .ForMember(dest => dest.UserName, u => u.MapFrom(reg => reg.Email));

            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
