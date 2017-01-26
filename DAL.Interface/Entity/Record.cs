using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Entity
{
    public class RecordDal : IEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public System.DateTime DateOfPublication { get; set; }
        public int IdPeople { get; set; }
        public string Theme { get; set; }
        public int IdTheme { get; set; }
     
    }
}
