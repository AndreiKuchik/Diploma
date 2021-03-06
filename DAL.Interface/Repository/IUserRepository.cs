﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Entity;

namespace DAL.Interface.Repository
{
    public interface IUserRepository:IRepository<DalPerson>
    {
        int Update(DalPerson person);
        int Login(DalPerson person);
        DalPerson GetById(int id);
        IEnumerable<DalPerson> GetAllWhithCount();
        IEnumerable<DalPerson> GetAllFrineds(int Id);
        void ToSubscribe(int idOwner, int idUser);
        IEnumerable<int> GetSubscribe(int idOwner);
        IEnumerable<DalPerson> Search(string name);
        void Unsubscribe(int idOwner, int idGuest);
    }
}
