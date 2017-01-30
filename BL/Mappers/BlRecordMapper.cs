using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Interface.Entities;
using DAL.Interface.Entity;

namespace BL.Mappers
{
    public static class BlRecordMapper
    {
        public static RecordDal ToDalRecord(this RecordBL bllrecord)
        {
            return new RecordDal()
            {
                Id = bllrecord.Id,
                IdPeople = bllrecord.IdPeople,
                Theme = bllrecord.Theme,
                Text = bllrecord.Text,
                DateOfPublication = bllrecord.DateOfPublication
               
            };
        }

        public static RecordBL ToBlRecord(this RecordDal dalRecod)
        {
            return new RecordBL()
            {
                Id = dalRecod.Id,
                Theme = dalRecod.Theme,
                IdPeople = dalRecod.IdPeople,
                Text = dalRecod.Text,
                DateOfPublication = dalRecod.DateOfPublication,
                Comments = dalRecod.Comments.Select(comment=>comment.ToBlComment())
            };
        }
    }
}
