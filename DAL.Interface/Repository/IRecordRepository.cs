using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Entity;

namespace DAL.Interface.Repository
{
    public interface IRecordRepository:IRepository<RecordDal>
    {
        IEnumerable<RecordDal> GetAll(int Id);
        bool ChangeRecord(RecordDal recordDal);

        bool DeleteByIdUser(int id);
    }
}
