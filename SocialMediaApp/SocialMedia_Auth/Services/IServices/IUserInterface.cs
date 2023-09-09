using SocialMedia_Auth.Models.Dtos;

namespace SocialMedia_Auth.Services.IServices
{
    public interface IUserInterface
    {
        Task<string> RegisterUser(RegisterRequestDto registerRequestDto);

        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);

        Task<bool> AssignUserRole(string email, string Rolename);
    }
}
