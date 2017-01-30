using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Interface.Services;
using BL.Interface.Entities;
using BL.Mappers;
using DAL.Interface.Repository;

namespace BL.Services
{
    public class ResourceServices:IResourceServices
    {
        private readonly IUnitOfWork uow;
        private readonly ISourceRepository sourceRepository;

        public ResourceServices(IUnitOfWork uow, ISourceRepository repository)
        {
            this.uow = uow;
            this.sourceRepository = repository;
        }
        public void SaveResouce(ResourceBL source)
        {
           sourceRepository.SaveResouce(source.ToDalSource());
        }
        public ResourceBL GetImage(int idResource)
        {
            return sourceRepository.GetImage(idResource).ToBlResorce();
        }
    }
}
