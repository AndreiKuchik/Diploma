using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Repository;
using DAL.Interface.Entity;
using ORM;

namespace DAL.Concrete
{
    public class CommentRepository: ICommentRepository
    {
        private readonly LocalDatabaseBlogEntities context = new LocalDatabaseBlogEntities();
       

        public bool Delete(int id)
        {
            try
            {

                context.Comments.Remove(context.Comments.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<DalComment> GetAll(int IdRecord)
        {

            try
            {
                var q = (from s in context.Comments where s.IdRecord == IdRecord select s);
                List<DalComment> model = new List<DalComment>();
                foreach (var record in q)
                {
                    DalComment vm = new DalComment();
                    vm.Id = record.IdComments;
                    vm.IdPeople = record.IdPeople;
                    vm.IdRecord = record.IdRecord;
                    vm.Comments = record.Comments;
                    model.Add(vm);

                }
                foreach (var comment in model)
                {
                    UserRepository userRepository = new UserRepository();
                    comment.Author = userRepository.GetById(comment.IdPeople);

                }

                IEnumerable<DalComment> mod = model;
                return mod;

            }
            catch (Exception)
            {

                return null;
            }
        }

        public int Create(DalComment e)
        {
            try
            {
                var comment = new Comment()
                {
                    IdPeople = e.IdPeople,
                    IdRecord = e.IdRecord,
                    Comments = e.Comments

                };
                context.Comments.Add(comment);
                context.SaveChanges();

                return 1;
            }
            catch (Exception exception)
            {
                return -1;

            }
        }
        
        public bool DeleteAllForRecord(int idRecord)
        {
            try
            {
                var ListComments = (from record in context.Comments where record.IdRecord == idRecord select record);
                foreach (var friend in ListComments)
                {
                    context.Comments.Remove(friend);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
