using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Interface.Entities;

namespace BL.Interface.Services
{
    public interface IThemeServices
    {
        int CreateTheme(ThemeBL theme);
        IEnumerable<ThemeBL> GetAllThemes();
        IEnumerable<ThemeBL> GetAllWithCount();

        IEnumerable<ThemeBL> Search(string name);
        bool Delete(int id);
    }
}
