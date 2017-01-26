using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Entity
{
    public class Resourses:IEntity
    {
        public int Id { get; set; }
        public byte[] Resourse { get; set; }
    }
}
