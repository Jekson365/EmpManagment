using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Dto.Comments;
using MyApp.Interfaces;
using MyApp.Models.Comments;

namespace MyApp.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Comment?> Create(NewCommentDto newCommentDto)
        {
            var task = _context.Tasks.Find(newCommentDto.TaskId);
            if (task == null)
            {
                return null;
            }
            var newComment = new Comment
            {
                Content = newCommentDto.Content,
                TaskId = newCommentDto.TaskId,
                UserId = newCommentDto.UserId
            };
            await _context.Comments.AddAsync(newComment);
            await _context.SaveChangesAsync();

            return newComment;
        }

        public async Task<List<Comment>> GetAll()
        {
            var comments = await _context.Comments.ToListAsync();

            return comments;
        }
    }
}