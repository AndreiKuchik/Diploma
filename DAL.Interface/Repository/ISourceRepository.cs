using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Entity;

namespace DAL.Interface.Repository
{
    public interface ISourceRepository
    {
        void SaveResouce(SourceDal source);
        SourceDal GetImage(int idResource);
    }
}
