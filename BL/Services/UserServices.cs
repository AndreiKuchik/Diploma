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
    public class UserServices: IUserServices
    {
       
        private readonly IUnitOfWork uow;
        private readonly IUserRepository userRepository;

        public UserServices(IUnitOfWork uow, IUserRepository repository)
        {
            this.uow = uow;
            this.userRepository = repository;
        }
        public int CreateUser(PersonBL user)
        {
            int id = userRepository.Create(user.ToDalUser());
            uow.Commit();
            return id;
        }

        public PersonBL Login(PersonBL login)
        {

            return userRepository.Login(login.ToDalUser()).ToBlPerson();
        }


        public IEnumerable<PersonBL> GetAllFriends(int id)
        {
            return userRepository.GetAllFrineds(id).Select(friend => friend.ToBlPerson());
        }
        
        public IEnumerable<PersonBL> GetAllWhithCount()
        {
            return userRepository.GetAllWhithCount().Select(friend => friend.ToBlPerson());
        }
        
        public PersonBL GetById(int id)
        {
            return userRepository.GetById(id).ToBlPerson();
        }
        
        public IEnumerable<int> ToSubscribe(int idOwner, int idUser)
        {
            return userRepository.ToSubscribe(idOwner, idUser);
        }
        
        public IEnumerable<int> GetSubscribe(int idOwner)
        {
            return userRepository.GetSubscribe(idOwner);
        }

        public bool Delete(int id)
        {
            return userRepository.Delete(id);
        }
    }
}
