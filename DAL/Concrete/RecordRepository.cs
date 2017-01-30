using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Repository;
using DAL.Interface.Entity;
using ORM;

namespace DAL.Concrete
{
    public class RecordRepository:IRecordRepository
    {
        private readonly LocalDatabaseBlogEntities context = new LocalDatabaseBlogEntities();
        public int Create(RecordDal e)
        {
            int idTheme;
            var q = (from s in context.Themes where s.TitleOfTheme.Equals(e.Theme) select s).FirstOrDefault();
            if (q == null)
            {

                DalTheme newTheme= new DalTheme();
                newTheme.TitleOfTheme = e.Theme;
                ThemeRepository rep = new ThemeRepository();
                idTheme = rep.Create(newTheme);
                if (idTheme < 0)
                {
                    return -1;
                }
            }
            else
            {
                idTheme = q.IdTheme;
            }
            
            try
            {
                   var record = new Record()
                    {
                       
                        Text = e.Text,
                        DateOfPublication = DateTime.Now,
                        IdPeople = e.IdPeople,
                        IdTheme = idTheme

                    };
                    context.Records.Add(record);
                    context.SaveChanges();
                    var id = (from s in context.Records where s.Text == e.Text select s).FirstOrDefault();

                    return id.IdRecord;
            }
            catch (Exception exception)
            {
                return -1;

            }
        }
        
        public bool Delete(int id)
        {

            try
            {
                
                context.Records.Remove(context.Records.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
       
        }

        public bool DeleteByIdTheme(int IdTheme)
        {
            try
            {
               
                var ListRecord = (from record in context.Records where record.IdTheme == IdTheme select record);
                foreach (var friend in ListRecord)
                {
                    context.Records.Remove(friend);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public IEnumerable<RecordDal> GetAll(int IdP)
        {
            try
            {
                 CommentRepository commentRepository = new CommentRepository();
                var q = (from s in context.Records where s.IdPeople == IdP select s);
                List<RecordDal> model = new List<RecordDal>();
                foreach (var record in q)
                {
                    RecordDal vm = new RecordDal();
                    vm.Id = record.IdRecord;
                    vm.DateOfPublication = record.DateOfPublication;
                    vm.IdPeople = record.IdPeople;
                    vm.Text = record.Text;
                    vm.IdTheme = record.IdTheme;
                    model.Add(vm);

                }
                foreach (var record in model)
                {
                    var them = (from s in context.Themes where s.IdTheme==record.IdTheme select s).FirstOrDefault();
                    record.Theme = them.TitleOfTheme;
                    record.Comments = commentRepository.GetAll(record.Id);

                }
               
               
                IEnumerable<RecordDal> mod = model;
                return mod;
                
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<RecordDal> GetAll()
        {
            try
            {
                return context.Records.Select(record => new RecordDal()
                {
                     Id = record.IdRecord,
                     DateOfPublication = record.DateOfPublication,
                     IdPeople = record.IdPeople,
                     Text = record.Text,
                     IdTheme = record.IdTheme,

                });
                
               
            }
            catch (Exception)
            {

                return null;
            }
          
        }
        public bool ChangeRecord(RecordDal recordDal)
        {
            int idTheme;
            var q = (from s in context.Themes where s.TitleOfTheme.Equals(recordDal.Theme) select s).FirstOrDefault();
            if (q == null)
            {

                DalTheme newTheme = new DalTheme();
                newTheme.TitleOfTheme = recordDal.Theme;
                ThemeRepository rep = new ThemeRepository();
                idTheme = rep.Create(newTheme);
                if (idTheme < 0)
                {
                    return false;
                }
            }
            else
            {
                idTheme = q.IdTheme;
            }
          try
            {
               
                Record record = context.Records.Find(recordDal.Id);
                record.Text = recordDal.Text;
                record.IdTheme = idTheme;
                context.Entry(record).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
       
        }
        public bool DeleteByIdUser(int id)
        {
            try
            {
            CommentRepository comment = new CommentRepository();
            var ListIdFriends = (from record in context.Records where record.IdPeople == id select record);
            foreach (var friend in ListIdFriends)
            {
                comment.DeleteAllForRecord(friend.IdRecord);
                context.Records.Remove(friend);
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
