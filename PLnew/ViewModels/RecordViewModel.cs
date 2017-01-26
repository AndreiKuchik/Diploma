using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PLnew.Models
{
    public class RecordViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Recording can not be empty")]
        [StringLength(140, MinimumLength = 2, ErrorMessage = "The record must be from 2 to 140 characters")]
        //[RegularExpression (@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,20}", ErrorMessage = "Mistyped address")]
        public string Record { get; set; }

        public DateTime DateOfPublication { get; set; }
        public string Theme { get; set; }

        public int IdPeople { get; set; }

    }
}