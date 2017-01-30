using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
//using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using PLnew.Models;
using BL.Interface.Entities;

namespace PLnew.Infrastructure.Mappers
{
    public static class MVCUserMappers
    {
        #region Create user

        public static PersonBL ToBllUser(this RegistrationViewModel userViewModel)
        {
            //var roles = new List<IRole>();
            //roles.Add(userViewModel.Role);
            return new PersonBL()
            {
                Login = userViewModel.Login,
                FirstName = userViewModel.Name,
                Password = userViewModel.Password,
                LastName = userViewModel.Surname,
                MobilPhone = userViewModel.MNumber,
                EmailAddress = userViewModel.Email
                
            };
        }

        public static PersonBL ToBllPerson(this PersonViewModel userViewModel)
        {
            //var roles = new List<IRole>();
            //roles.Add(userViewModel.Role);
            return new PersonBL()
            {
                IdPeople = userViewModel.Id,
                IdRole = userViewModel.IdRole,
                Login = userViewModel.Login,
                FirstName = userViewModel.Name,
                Password = userViewModel.Password,
                LastName = userViewModel.Surname,
                MobilPhone = userViewModel.MNumber,
                EmailAddress = userViewModel.Email

            };
        }
        public static PersonViewModel ToPLUser(this PersonBL userModel)
        {
            //var roles = new List<IRole>();
            //roles.Add(userViewModel.Role);
            return new PersonViewModel()
            {
                Login = userModel.Login,
                Email = userModel.EmailAddress,
                Password = userModel.Password,
                Surname = userModel.LastName,
                MNumber = userModel.MobilPhone,
                Name = userModel.FirstName,
                Id = userModel.IdPeople,
                IdRole = userModel.IdRole,
                CountREcord = userModel.CountRecord

            };
        }

        #endregion
    }
}