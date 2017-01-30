using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL.Interface.Entities;
using PLnew.ViewModels;

namespace PLnew.Infrastructure.Mappers
{
    public static class ResourceMapper
    {
        public static ResourceBL ToBLSource(this ResourseViewModel bllresource)
        {
            return new ResourceBL()
            {
                IdResourse = bllresource.IdResourse,
                IdPeople = bllresource.IdPeople,
                IdRecord = bllresource.IdRecord,
                ImageMimeType = bllresource.ImageMimeType,
                Resourse = bllresource.Resourse
            };
        }

        public static ResourseViewModel ToPLSource(this ResourceBL bllresource)
        {
            return new ResourseViewModel()
            {
                IdResourse = bllresource.IdResourse,
                IdPeople = bllresource.IdPeople,
                IdRecord = bllresource.IdRecord,
                ImageMimeType = bllresource.ImageMimeType,
                Resourse = bllresource.Resourse
            };
        }
    }
}