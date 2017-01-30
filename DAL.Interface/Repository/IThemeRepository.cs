using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Repository;
using DAL.Interface.Entity;

namespace DAL.Interface.Repository
{
    public interface IThemeRepository:IRepository<DalTheme>
    {
        IEnumerable<DalTheme> GetAll();
        IEnumerable<DalTheme> GetAllWithCount();

        IEnumerable<DalTheme> Search(string name);
        bool Delete(int id);
    }
}
