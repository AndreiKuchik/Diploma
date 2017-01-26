using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Entity
{
    public class Comment:IEntity
    {
            public int Id { get; set; }
            public string Comments { get; set; }
            public int IdPeople { get; set; }
            public int IdRecord { get; set; }
        
    }
}
