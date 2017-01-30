using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interface.Entities
{
    public class ResourceBL
    {
        public int IdResourse { get; set; }
        public byte[] Resourse { get; set; }
        public int IdRecord { get; set; }
        public int IdPeople { get; set; }
        public string ImageMimeType { get; set; }
    }
}
