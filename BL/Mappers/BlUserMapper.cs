using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Interface.Entities;
using DAL.Interface.Entity;
namespace BL.Mappers
{
    public static class BlUserMapper
    {
        public static DalPerson ToDalUser(this PersonBL bllUser)
        {
            return new DalPerson()
            {
                Id = bllUser.IdPeople,
                EmailAddress = bllUser.EmailAddress,
                Login = bllUser.Login,
                FirstName = bllUser.FirstName,
                Password = bllUser.Password,
                IdRole = bllUser.IdRole,
                MobilPhone = bllUser.MobilPhone,
                LastName = bllUser.LastName
            };
        }

        public static PersonBL ToBlPerson(this DalPerson dalPerson)
        {
            return new PersonBL()
            {
                IdPeople = dalPerson.Id,
                EmailAddress = dalPerson.EmailAddress,
                Login = dalPerson.Login,
                FirstName = dalPerson.FirstName,
                Password = dalPerson.Password,
                IdRole = dalPerson.IdRole,
                MobilPhone = dalPerson.MobilPhone,
                LastName = dalPerson.LastName,
                CountRecord = dalPerson.CountRecord
            };
        }
    }
}
