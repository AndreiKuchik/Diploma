using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Repository;
using DAL.Interface.Entity;
using ORM;

namespace DAL.Concrete
{
    public class ThemeRepository:IThemeRepository
    {
        private readonly LocalDatabaseBlogEntities context = new LocalDatabaseBlogEntities();
        public int Create(DalTheme e)
        {
            try
            {
               
                    var theme = new Theme()
                    {
                        TitleOfTheme = e.TitleOfTheme,
                      

                    };
                    context.Themes.Add(theme);
                    context.SaveChanges();
                    var id = (from s in context.Themes where s.TitleOfTheme == e.TitleOfTheme select s).FirstOrDefault();

                    return id.IdTheme;
               

            }
            catch (Exception exception)
            {

                return -1;
            }
        }

        public bool Delete(int e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalTheme> GetAll()
        {
            try
            {
                return context.Themes.Select(theme => new DalTheme()
                {
                    Id = theme.IdTheme,
                    TitleOfTheme = theme.TitleOfTheme,
                   

                });
                
                 
                //List<DalTheme> model = new List<DalTheme>();
                //foreach (var theme in themes)
                //{
                //    DalTheme vm = new DalTheme();
                //    vm.Id = theme.IdTheme;
                //    vm.TitleOfTheme = theme.TitleOfTheme;
                //    model.Add(vm);

                //}
                //IEnumerable<DalTheme> mod = model;
                //return mod;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public IEnumerable<DalTheme> GetAllWithCount()
        {
            ThemeRepository repository =new ThemeRepository();
            IEnumerable<DalTheme> list = repository.GetAll();
            RecordRepository rep = new RecordRepository();
            IEnumerable<RecordDal> reclist = rep.GetAll();
            List<DalTheme> listnew=new List<DalTheme>();
            foreach (var theme in list)
            {
                foreach (var record in reclist)
                {
                    if (record.IdTheme == theme.Id)
                    {
                        theme.Count++;
                    }
                }
                listnew.Add(theme);
            }
            return listnew;

        }
    }
}
