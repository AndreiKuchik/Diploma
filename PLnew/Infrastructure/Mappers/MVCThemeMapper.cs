using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL.Interface.Entities;
using PLnew.Models;
using PLnew.ViewModels;

namespace PLnew.Infrastructure.Mappers
{
    public static class MVCThemeMapper
    {
        public static ThemeViewModel ToMVCTheme(this ThemeBL themeBl)
        {
            //var roles = new List<IRole>();
            //roles.Add(userViewModel.Role);
            return new ThemeViewModel()
            {
                Id = themeBl.Id,
                TitleOfTheme = themeBl.TitleOfTheme,
                Count= themeBl.Count

            };
        }
    }
}