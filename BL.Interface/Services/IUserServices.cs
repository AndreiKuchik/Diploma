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
        PersonBL Login(PersonBL login);
        PersonBL GetById(int id);
        int CreateUser(PersonBL user);
        IEnumerable<PersonBL> GetAllFriends(int id);
        IEnumerable<PersonBL> GetAllWhithCount();
        IEnumerable<int> ToSubscribe(int idOwner, int idUser);
        IEnumerable<int> GetSubscribe(int idOwner);
    }
}
