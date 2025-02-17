using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyApp.Dto.Comments;
using MyApp.Interfaces;
using MyApp.Mappers;

namespace MyApp.Controllers.Comment
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        public ICommentRepository _commentRepo;
        public CommentController(ICommentRepository commentRepo)
        {
            _commentRepo = commentRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _commentRepo.GetAll();

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NewCommentDto newCommentDto)
        {
            var result = await _commentRepo.Create(newCommentDto);
            if (result == null)
            {
                return NotFound("task not found!");
            }
            return Ok(result.ToNewCommentDto());
        }
    }
}