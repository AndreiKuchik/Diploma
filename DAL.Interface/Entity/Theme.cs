using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Entity
{
    public class DalTheme : IEntity
    {
        public int Id { get; set; }
        public string TitleOfTheme { get; set; }
        public int Count { get; set; }
    }
}
