//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ORM
{
    using System;
    using System.Collections.Generic;
    
    public partial class Record
    {
        public Record()
        {
            this.Comments = new HashSet<Comment>();
            this.Resourses = new HashSet<Resours>();
        }
    
        public int IdRecord { get; set; }
        public string Text { get; set; }
        public System.DateTime DateOfPublication { get; set; }
        public int IdPeople { get; set; }
        public int IdTheme { get; set; }
    
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual Person Person { get; set; }
        public virtual Theme Theme { get; set; }
        public virtual ICollection<Resours> Resourses { get; set; }
    }
}
