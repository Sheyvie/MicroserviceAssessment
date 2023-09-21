
using Newtonsoft.Json;
using SocialMedia_FrontEnd.Models;
using SocilaMedia_FrontEnd.Models.Comments;
using System.Text;

namespace SocialMedia_FrontEnd.Services.Comments
{
    public class CommentService : ICommentInterface

    {

        private readonly HttpClient _httpClient;
        private readonly string BASEURL = "https://localhost:7002";
        public CommentService(HttpClient httpClient)
        {

            _httpClient = httpClient;

        }
        public async Task<ResponseDto> AddCommentAsync(CommentRequestDto commentRequestDto)
        {
            var request = JsonConvert.SerializeObject(commentRequestDto);
            var bodyContent = new StringContent(request, Encoding.UTF8, "application/json");


            var response = await _httpClient.PostAsync($"{BASEURL}/api/Comment", bodyContent);
            var content = await response.Content.ReadAsStringAsync();

            var results = JsonConvert.DeserializeObject<ResponseDto>(content);

            if (results.IsSuccess)
            {
                //change this to a list of products
                return results;
            }
            return new ResponseDto();
        }

        public async Task<ResponseDto> DeleteCommentAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{BASEURL}/api/Comment?id={id}");
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<ResponseDto>(content);

            if (results.IsSuccess)
            {

                return results;
            }
            return new ResponseDto();
        }

        public async Task<Comment> GetCommentByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"{BASEURL}/api/Comment/GetById/{id}");
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<ResponseDto>(content);

            if (results.IsSuccess)
            {

                return JsonConvert.DeserializeObject<Comment>(results.Result.ToString());

            }
            return new Comment();
        }

        public Task<List<Comment>> GetCommentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> UpdateCommentAsync(Guid id , CommentRequestDto commentRequestDto)
        {
            throw new NotImplementedException();
        }

        
       
    }
}
