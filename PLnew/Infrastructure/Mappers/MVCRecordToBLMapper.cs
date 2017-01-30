using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL.Interface.Entities;
using PLnew.Models;

namespace PLnew.Infrastructure.Mappers
{
    public static class MVCRecordToBLMapper
    {
        public static RecordBL ToBlRecord(this RecordViewModel record)
        {
            
            return new RecordBL()
            {
                Id = record.Id,
                IdPeople = record.IdPeople,
                Theme = record.Theme,
                Text = record.Record
            };
        }

        public static RecordViewModel ToMVCRecord(this RecordBL record)
        {
            return new RecordViewModel()
            {
                IdPeople = record.IdPeople,
                Theme = record.Theme,
                Record = record.Text,
                Id = record.Id,
                DateOfPublication = record.DateOfPublication,
                Comments = record.Comments.Select(comment => comment.ToMVCComment())
                
            };
        }
    }
}