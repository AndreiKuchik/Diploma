using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLnew.ViewModels
{
    public class ResourseViewModel
    {
        public int IdResourse { get; set; }
        public byte[] Resourse { get; set; }
        public int IdRecord { get; set; }
        public int IdPeople { get; set; }
        public string ImageMimeType { get; set; }
    }
}