using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Interface.Entities;
using DAL.Interface.Entity;


namespace BL.Mappers
{
    public static class ResourceMapper
    {
        public static SourceDal ToDalSource(this ResourceBL bllresource)
        {
            return new SourceDal()
            {
                IdResourse = bllresource.IdResourse,
                IdPeople = bllresource.IdPeople,
                IdRecord = bllresource.IdRecord,
                ImageMimeType = bllresource.ImageMimeType,
                Resourse = bllresource.Resourse
             };
        }

        public static ResourceBL ToBlResorce(this SourceDal dalResorce)
        {
            return new ResourceBL()
            {
                IdResourse = dalResorce.IdResourse,
                IdPeople = dalResorce.IdPeople,
                IdRecord = dalResorce.IdRecord,
                Resourse = dalResorce.Resourse,
                ImageMimeType = dalResorce.ImageMimeType

            };
        }
    }
}
