using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia_Auth.Models.Dtos;
using SocialMedia_Auth.Services.IServices;
using SocialMedia_Email.Models;
using SocialMediaMessageApp;

namespace SocialMedia_Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserInterface _userInterface;
        private readonly ResponseDto _response;
        private readonly IConfiguration _configuration;
        private readonly IMessageBus _messageBus;
        public UserController(IUserInterface userInterface, IConfiguration configuration , IMessageBus messageBus)
        {
            _userInterface = userInterface;
            _response = new ResponseDto();
            _configuration = configuration;
            _messageBus = messageBus;
        }   

        [HttpPost("register")]
        public async Task<ActionResult<ResponseDto>> AddUSer(RegisterRequestDto registerRequestDto)
        {
            var errorMessage = await _userInterface.RegisterUser(registerRequestDto);
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                
                _response.IsSuccess = false;
                _response.Message = errorMessage;

                return BadRequest(_response);
            }
            var queueName = _configuration.GetSection("QueuesandTopics:RegisterUser").Get<string>(); ;
            var message = new UserMessage()
            {
                Email = registerRequestDto.Email,
                Name = registerRequestDto.Name
             };

            await _messageBus.PublishMessage(message, queueName);
            return Ok(_response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ResponseDto>> LoginUser(LoginRequestDto loginRequestDto)
        {
            var response = await _userInterface.Login(loginRequestDto);
            if (response.User == null)
            {
                
                _response.IsSuccess = false;
                _response.Message = "Invalid Credential";

                return BadRequest(_response);
            }
            _response.Result = response;
            return Ok(_response);
        }

        [HttpPost("AssignRole")]
        public async Task<ActionResult<ResponseDto>> AssignRole(RegisterRequestDto registerRequestDto)
        {
            var response = await _userInterface.AssignUserRole(registerRequestDto.Email, registerRequestDto.Role);
            if (!response)
            {
               
                _response.IsSuccess = false;
                _response.Message = "Error Occured";

                return BadRequest(_response);
            }
            _response.Result = response;
            return Ok(_response);
        }
    }
}
