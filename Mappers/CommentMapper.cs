using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Dto.Comments;
using MyApp.Models.Comments;

namespace MyApp.Mappers
{
    public static class CommentMapper
    {
        public static NewCommentDto ToNewCommentDto(this Comment comment)
        {
            return new NewCommentDto
            {
                Content = comment.Content,
                TaskId = comment.TaskId
            };
        }
    }
}