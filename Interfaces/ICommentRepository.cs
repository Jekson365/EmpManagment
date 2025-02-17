using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Dto.Comments;
using MyApp.Models.Comments;

namespace MyApp.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAll();
        Task<Comment?> Create(NewCommentDto newCommentDto);
    }
}