using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Interface.Entities;

namespace BL.Interface.Services
{
    public interface IResourceServices
    {
        void SaveResouce(ResourceBL source);
        ResourceBL GetImage(int idResource);
    }
}
