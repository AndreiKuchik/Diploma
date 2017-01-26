using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Interface.Entities;

namespace BL.Interface.Services
{
    public interface IRecordService
    {
        int CreateRecord(RecordBL record);
        IEnumerable<RecordBL> GetAllRecords(int id);
        bool Delete(int id);
        bool ChangeRecord(RecordBL recordBl);
    }
}
