using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interface.Entities
{
    public class CommentBL
    {
        public int Id { get; set; }
        public string Comments { get; set; }
        public int IdPeople { get; set; }
        public int IdRecord { get; set; }

        public PersonBL Author { get; set; }
    }
}
