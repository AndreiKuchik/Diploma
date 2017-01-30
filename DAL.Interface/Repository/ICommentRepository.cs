using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Entity;

namespace DAL.Interface.Repository
{
    public interface ICommentRepository:IRepository<DalComment>
    {
        IEnumerable<DalComment> GetAll(int Id);
        bool DeleteAllForRecord(int idRecord);
    }
}
