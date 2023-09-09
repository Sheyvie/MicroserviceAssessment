using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocilaMedia_Comment.Models;
using SocilaMedia_Comment.Models.Dtos;
using SocilaMedia_Comment.Services.Iservice;
using System.Data;

namespace SocilaMedia_Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICommentInterface _commentInterface;
        private readonly ResponseDto _responseDto;

        public CommentController(IMapper mapper, ICommentInterface commentInterface)
        {
            _mapper = mapper;
            _commentInterface = commentInterface;
            _responseDto = new ResponseDto();
        }
        [HttpGet]
        public async Task<ActionResult<ResponseDto>> GetAllComments()
        {
            var comments = await _commentInterface.GetCommentsAsync();
            if (comments == null)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Error Occured";
                return BadRequest(_responseDto);
            }

            _responseDto.Result = comments;
            return Ok(_responseDto);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ResponseDto>> AddPost([FromBody]CommentRequestDto commentRequest)
        {
            var newComment = _mapper.Map<Comments>(commentRequest);
            var response = await _commentInterface.AddCommentAsync(newComment);
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
        [Authorize]
        public async Task<ActionResult<ResponseDto>> UpdateComment(Guid id, CommentRequestDto commentRequestDto)
        {
            var comment = await _commentInterface.GetCommentByIdAsync(id);
            if (comment == null)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Error Occured";
                return BadRequest(_responseDto);
            }
            //update
            var updated = _mapper.Map(commentRequestDto, comment);
            var response = await _commentInterface.UpdateCommentAsync(updated);
            _responseDto.Result = response;
            return Ok(_responseDto);
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<ResponseDto>> DeleteComment(Guid id)
        {
            var comment = await _commentInterface.GetCommentByIdAsync(id);
            if (comment == null)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Error Occured";
                return BadRequest(_responseDto);
            }
            //delete

            var response = await _commentInterface.DeleteCommentAsync(comment);
            _responseDto.Result = response;
            return Ok(_responseDto);
        }
    }
}
