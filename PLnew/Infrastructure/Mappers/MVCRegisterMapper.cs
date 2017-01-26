using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL.Interface.Entities;
using PLnew.Models;
using PLnew.ViewModels;

namespace PLnew.Infrastructure.Mappers
{
    public static class MVCRegisterMapper
    {
        public static PersonBL ToBlRegister(this RegistrationViewModel person)
        {
            //var roles = new List<IRole>();
            //roles.Add(userViewModel.Role);
            return new PersonBL()
            {
                Login = person.Login,
                Password = person.Password

            };
        }
    }
}