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
    public class RecordServices:IRecordService
    {
        private readonly IUnitOfWork uow;
        private readonly IRecordRepository recordRepository;

        public RecordServices(IUnitOfWork uow, IRecordRepository repository)
        {
            this.uow = uow;
            this.recordRepository = repository;
        }
     
        public int CreateRecord(RecordBL record)
        {
            return recordRepository.Create(record.ToDalRecord());
        }

        public IEnumerable<RecordBL> GetAllRecords(int Id)
        {
            return recordRepository.GetAll(Id).Select(record => record.ToBlRecord());
        }
        public bool Delete(int id)
        {
            return recordRepository.Delete(id);
        }


        public bool ChangeRecord(RecordBL recordBl)
        {
            return recordRepository.ChangeRecord(recordBl.ToDalRecord());
        }
    }
}
