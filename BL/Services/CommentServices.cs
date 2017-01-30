using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Interface.Entities;
using BL.Interface.Services;
using BL.Mappers;
using DAL.Interface.Repository;

namespace BL.Services
{
     public class CommentServices:ICommentService
    {
        private readonly IUnitOfWork uow;
        private readonly ICommentRepository commentRepository;

        public CommentServices(IUnitOfWork uow, ICommentRepository repository)
        {
            this.uow = uow;
            this.commentRepository = repository;
        }
        public int CreateComment(CommentBL comment)
        {
            return commentRepository.Create(comment.ToDalComment());
        }


        public IEnumerable<CommentBL> GetAll(int idRecord)
        {
            return commentRepository.GetAll(idRecord).Select(comment => comment.ToBlComment());
        }


        public bool Delete(int id)
        {
            return commentRepository.Delete(id);
        }
    }
}
