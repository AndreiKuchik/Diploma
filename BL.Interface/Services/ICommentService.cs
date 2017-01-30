using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Interface.Entities;

namespace BL.Interface.Services
{
    public interface ICommentService
    {
        int CreateComment(CommentBL comment);
        IEnumerable<CommentBL> GetAll(int idRecord);
        bool Delete(int id);
    }
}
