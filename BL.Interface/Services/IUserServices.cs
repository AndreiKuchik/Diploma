using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Interface.Entities;

namespace BL.Interface.Services
{
    public interface IUserServices
    {
        bool Delete(int id);
        int Login(PersonBL login);
        PersonBL GetById(int id);
        int CreateUser(PersonBL user);
        IEnumerable<PersonBL> GetAllFriends(int id);
        IEnumerable<PersonBL> GetAllWhithCount();
        void ToSubscribe(int idOwner, int idUser);
        bool GetSubscribe(int idOwner, int idGuest);
        int Update(PersonBL person);
        IEnumerable<PersonBL> Search(string name);
        void Unsubscribe(int idOwner, int idGuest);
    }
}
