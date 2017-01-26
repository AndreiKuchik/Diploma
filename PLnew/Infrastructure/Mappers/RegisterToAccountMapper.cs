using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PLnew.Models;
using PLnew.ViewModels;

namespace PLnew.Infrastructure.Mappers
{
    public static class RegisterToAccountMapper
    {
        public static PersonViewModel RefisterToPerson(this RegistrationViewModel reg, int id )
        {
            return new PersonViewModel()
            {
                Login = reg.Login,
                Name = reg.Name,
                Password = reg.Password,
                Surname = reg.Surname,
                MNumber = reg.MNumber,
                Email = reg.Email,
                Id = id,
               
            };
        }
    }
}