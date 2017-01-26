using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Interface.Entities;
using DAL.Interface.Entity;

namespace BL.Mappers
{
    public static class BlThemeMapper
    {
        public static ThemeBL ToBllTheme(this DalTheme dalTheme)
        {
            return new ThemeBL()
            {
                Id = dalTheme.Id,
                TitleOfTheme = dalTheme.TitleOfTheme,
                Count = dalTheme.Count
            };
        }
    }
}
