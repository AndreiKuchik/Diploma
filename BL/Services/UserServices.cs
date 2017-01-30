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

        public int Login(PersonBL login)
        {

            return userRepository.Login(login.ToDalUser());
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
        
        public void ToSubscribe(int idOwner, int idUser)
        {
             userRepository.ToSubscribe(idOwner, idUser);
        }
        
        public bool GetSubscribe(int idOwner, int idGuest)
        {
            
            IEnumerable<int> listIdFriends = userRepository.GetSubscribe(idOwner);
             foreach (var sign in listIdFriends)
                {
                    if (sign == idGuest)
                    {
                        return true;
                    }
                }
            return false;
        }

        public bool Delete(int id)
        {
            return userRepository.Delete(id);
        }
        
        public int Update(PersonBL person)
        {
            return userRepository.Update(person.ToDalUser());
        }
        
        public IEnumerable<PersonBL> Search(string name)
        {
            return userRepository.Search(name).Select(person => person.ToBlPerson());
        }

        public void Unsubscribe(int idOwner, int idGuest)
        {
            userRepository.Unsubscribe(idOwner,idGuest);
        }
    }
}
