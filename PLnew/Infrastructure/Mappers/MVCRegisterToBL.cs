using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL.Interface.Entities;
using PLnew.Models;

namespace PLnew.Infrastructure.Mappers
{
    public static class MVCRegisterToBL
    {
        public static PersonBL ToBllLogin(this LoginViewModel userViewModel)
        {
            //var roles = new List<IRole>();
            //roles.Add(userViewModel.Role);
            return new PersonBL()
            {
                Login = userViewModel.Login,
                Password = userViewModel.Password,
                
            };
        }
    }
}