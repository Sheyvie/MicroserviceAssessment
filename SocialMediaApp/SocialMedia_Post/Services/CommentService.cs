using Newtonsoft.Json;
using SocialMedia_Post.Models.Dtos;
using SocialMedia_Post.Services.Iservices;

namespace SocialMedia_Post.Services
{
    public class CommentService:ICommentInterface
    {
        private readonly IHttpClientFactory _clientFactory;
        public CommentService(IHttpClientFactory clientFactory)
        {

            _clientFactory = clientFactory;

        }
        public async Task<IEnumerable<CommentsDto>> GetCommentsAsync()
        {
            //Create a client
            var client = _clientFactory.CreateClient("Comment");
            var response = await client.GetAsync("/api/Comment");
            var content = await response.Content.ReadAsStringAsync();
            var responseDto = JsonConvert.DeserializeObject<ResponseDto>(content);

            if (responseDto.IsSuccess)
            {
                return JsonConvert.DeserializeObject<IEnumerable<CommentsDto>>(Convert.ToString(responseDto.Result));
            }
            return new List<CommentsDto>();

        }
    }
}
