using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL.Interface.Entities;
using PLnew.Models;

namespace PLnew.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int IdRecord { get; set; }
        public int IdUser { get; set; }

        public PersonViewModel Author { get; set; }
    }
}