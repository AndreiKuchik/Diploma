using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Interface.Services;
using BL.Interface.Entities;
using BL.Mappers;
using DAL.Interface.Repository;
using DAL.Interface.Entity;

namespace BL.Services
{
    public class ThemeServices:IThemeServices
    {
        private readonly IUnitOfWork uow;
        private readonly IThemeRepository themeRepository;

        public ThemeServices(IUnitOfWork uow, IThemeRepository repository)
        {
            this.uow = uow;
            this.themeRepository = repository;
        }
     
        public int CreateTheme(ThemeBL theme)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ThemeBL> GetAllThemes()
        {
           
            return themeRepository.GetAll().Select(theme => theme.ToBllTheme());
        }


        public IEnumerable<ThemeBL> GetAllWithCount()
        {
            return themeRepository.GetAllWithCount().Select(theme => theme.ToBllTheme());
        }
    }
}
