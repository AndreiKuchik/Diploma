using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Entity
{
    public class Roles:IEntity
    {
        public int Id { get; set; }
        public string Role { get; set; }
    }
}
