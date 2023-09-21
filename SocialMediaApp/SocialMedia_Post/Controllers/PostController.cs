using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia_Post.Models.Dtos;
using SocialMedia_Post.Services.Iservices;
using static Azure.Core.HttpHeader;
using System.Data;
using SocialMedia_Post.Models;

namespace SocialMedia_Post.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPostInterface _postInterface;
        private readonly ResponseDto _responseDto;

        public PostController(IMapper mapper, IPostInterface postInterface)
        {
            _mapper = mapper;
            _postInterface = postInterface;
            _responseDto = new ResponseDto();
        }
        [HttpGet]
        public async Task<ActionResult<ResponseDto>> GetAllPosts()
        {
            var posts = await _postInterface.GetPostsAsync();
            if (posts == null)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Error Occured";
                return BadRequest(_responseDto);
            }

            _responseDto.Result = posts;
            return Ok(_responseDto);
        }

        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<ResponseDto>> AddPost(PostRequestDto postRequest)
        {
            var newPost = _mapper.Map<Post>(postRequest);
            var response = await _postInterface.AddPostAsync(newPost);
            if (string.IsNullOrWhiteSpace(response))
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Error Occured";
                return BadRequest(_responseDto);
            }

            _responseDto.Result = response;
            return Ok(_responseDto);
        }

        
        [HttpPut]
       // [Authorize]
        public async Task<ActionResult<ResponseDto>> UpdatePost(Guid id, PostRequestDto postRequestDto)
        {
            var post = await _postInterface.GetPostByIdAsync(id);
            if (post == null)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Error Occured";
                return BadRequest(_responseDto);
            }
            //updating
            var updated = _mapper.Map(postRequestDto, post);
            var response = await _postInterface.UpdatePostAsync(updated);
            _responseDto.Result = response;
            return Ok(_responseDto);
        }

        [HttpDelete]
        //[Authorize]
        public async Task<ActionResult<ResponseDto>> DeletePost(Guid id)
        {
            var post = await _postInterface.GetPostByIdAsync(id);
            if (post == null)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Error Occured";
                return BadRequest(_responseDto);
            }
            
            var response = await _postInterface.DeletePostAsync(post);
            _responseDto.Result = response;
            return Ok(_responseDto);
        }
        [HttpPost("{postId}/like")]
        public async Task<ActionResult> LikePost(Guid Id , Post post)
        {
            var posts = await _postInterface.GetPostByIdAsync(Id);
            if (post == null)
            {
                return NotFound();
            }

            // Update the like count in the database
            post.Likes++;

            await _postInterface.UpdatePostAsync(post);

            return Ok(_responseDto);
            
        }


        // Remove a like from a post with postId
        [HttpDelete("{postId}/like")]
        public async Task<ActionResult> UnLikePost(Guid Id ,Post post)
        {
            var posts = await _postInterface.GetPostByIdAsync(Id);
            if (post == null)
            {
                return NotFound();
            }

            // Update the dislike count in the database
            post.UnLike++;

            await _postInterface.UpdatePostAsync(post);

            return Ok(_responseDto);
        }

            
           
        

        // Fetch posts by a specific tag
        [HttpGet("tag/{tag}")]
        public async Task<ActionResult<IEnumerable<Post>>> GetPostsByHashtag(string tag)
        {
            // Implement logic to fetch posts by a specific hashtag
            var postsByTag = await _postInterface.GetPostsByTagAsync(tag);
            return Ok(postsByTag);
        }

    }
}
