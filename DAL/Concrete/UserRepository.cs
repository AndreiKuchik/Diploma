using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Exeption;
using DAL.Interface.Repository;
using DAL.Interface.Entity;
using ORM;


namespace DAL.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly LocalDatabaseBlogEntities context = new LocalDatabaseBlogEntities();
        public int Create(DalPerson e)
        {
            try
            {
                var persons = (from person in context.People where person.Login.Equals(e.Login) select person).FirstOrDefault();
                if (persons==null)
                {
                    var user = new Person()
                    {
                        Login = e.Login,
                        IdRole = 1,
                        EmailAddress = e.EmailAddress,
                        Password = e.Password,
                        MobilPhone = e.MobilPhone,
                        FirstName = e.FirstName,
                        LastName = e.LastName

                    };
                    context.People.Add(user);
                    context.SaveChanges();
                    var id = (from s in context.People where s.Login == e.Login select s).FirstOrDefault();

                    return id.IdPeople;
                }
                else
                    return 0;

            }
            catch (Exception exception)
            {

                return -1 ;
            }
        }

        public bool Delete(int id)
        {
            RecordRepository rec = new RecordRepository();
            rec.DeleteByIdUser(id);
            var ListIdFriends = (from record in context.Signs where record.IdOwner == id || record.IdSign==id select record);
            foreach (var friend in ListIdFriends)
            {
                context.Signs.Remove(friend);
                context.SaveChanges();
            }

            try
            {

                context.People.Remove(context.People.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public int Update(DalPerson entity)
        {
            
            try
            {

                var person = context.People.Find(entity.Id);
                if (person.Login == entity.Login)
                {
                    person.Login = entity.Login;
                    person.IdRole = 1;
                    person.EmailAddress = entity.EmailAddress;
                    person.Password = entity.Password;
                    person.MobilPhone = entity.MobilPhone;
                    person.FirstName = entity.FirstName;
                    person.LastName = entity.LastName;
                    context.Entry(person).State = EntityState.Modified;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    var persons = (from user in context.People where user.Login.Equals(entity.Login) select user).FirstOrDefault();
                    if (persons == null)
                    {
                        person.Login = entity.Login;
                        person.IdRole = 1;
                        person.EmailAddress = entity.EmailAddress;
                        person.Password = entity.Password;
                        person.MobilPhone = entity.MobilPhone;
                        person.FirstName = entity.FirstName;
                        person.LastName = entity.LastName;
                        context.Entry(person).State = EntityState.Modified;
                        context.SaveChanges();
                        return 1;
                    }
                    else
                        return 0;
                }
            }
            catch (Exception)
            {

                return -1;
            }
           
        }
        
        public IEnumerable<DalPerson> GetAll()
        {
            try
            {
                return context.People.Select(people => new DalPerson() 
                {
                    
                        Id = people.IdPeople,
                        Login = people.Login,
                        LastName = people.LastName,
                        EmailAddress = people.EmailAddress,
                        FirstName = people.FirstName,
                        MobilPhone = people.MobilPhone,
                        IdRole = people.IdRole

                });

            }
            catch (Exception)
            {

                return null;
            }
        }
        public IEnumerable<DalPerson> GetAllWhithCount()
        {
           
            UserRepository urep = new UserRepository();
            List<DalPerson> ListFriends = new List<DalPerson>();
            IEnumerable<DalPerson> list = urep.GetAll();
            RecordRepository rep = new RecordRepository();
            IEnumerable<RecordDal> reclist = rep.GetAll();
            foreach (var friend in list)
            {
                foreach (var record in reclist)
                {
                    if (record.IdPeople == friend.Id)
                    {
                        friend.CountRecord++;
                    }
                }
                ListFriends.Add(friend);
            }

            return ListFriends;
        }

        public int Login(DalPerson person)
        {
            try
            {
                
                var q = (from s in context.People where s.Login.Equals(person.Login) && s.Password.Equals(person.Password) select s).FirstOrDefault();

                if (q != null)
                {

                    return q.IdPeople;

                }
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public DalPerson GeyById(int id)
        {
            try
            {

                var q = context.People.Remove(context.People.Find(id));

                if (q != null)
                {

                    return new DalPerson()
                    {
                        Id = q.IdPeople,
                        Login = q.Login,
                        LastName = q.LastName,
                        EmailAddress = q.EmailAddress,
                        FirstName = q.FirstName,
                        MobilPhone = q.MobilPhone,
                        Password = q.Password,
                        IdRole = q.IdRole
                    };
                }
                
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<DalPerson> GetAllFrineds(int Id)
        {
            //List<DalPerson> ListFriends = new List<DalPerson>();
            var ListIdFriends = (from friend in context.Signs where friend.IdOwner == Id select friend);
            List<Person> ListModelFriends = new List<Person>();
            foreach (var friend in ListIdFriends)
            {
                ListModelFriends.Add((from model in context.People where model.IdPeople == friend.IdSign select model).FirstOrDefault());
            }
            List<DalPerson> ListFriends = new List<DalPerson>();
            foreach (var friend in ListModelFriends)
            {
                DalPerson vm = new DalPerson();
                vm.Id = friend.IdPeople;
                vm.EmailAddress = friend.EmailAddress;
                vm.FirstName = friend.FirstName;
                vm.IdRole = friend.IdRole;
                vm.LastName = friend.LastName;
                vm.Login = friend.Login;
                vm.MobilPhone = friend.MobilPhone;
                ListFriends.Add(vm);
            }
            RecordRepository rep = new RecordRepository();
            IEnumerable<RecordDal> reclist = rep.GetAll();
            foreach (var friend in ListFriends)
            {
                foreach (var record in reclist)
                {
                    if (record.IdPeople == friend.Id)
                    {
                        friend.CountRecord++;
                    }
                }
               
            }
            
            return ListFriends;
        }


        public DalPerson GetById(int id)
        {
            try
            {

                var q = (from s in context.People where s.IdPeople== id select s).FirstOrDefault();

                if (q != null)
                {

                    return new DalPerson()
                    {
                        Id = q.IdPeople,
                        Login = q.Login,
                        LastName = q.LastName,
                        EmailAddress = q.EmailAddress,
                        FirstName = q.FirstName,
                        MobilPhone = q.MobilPhone,
                        IdRole = q.IdRole
                    };
                }
               
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public void ToSubscribe(int idOwner, int idUser)
        {
            try
            {
                var sign = new Sign()
                {
                    IdSign = idUser,
                    IdOwner = idOwner


                };
                context.Signs.Add(sign);
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
                
               
            

        }
        
        public IEnumerable<int> GetSubscribe(int idOwner)
        {
            var ListIdFriends = (from friend in context.Signs where friend.IdOwner == idOwner select friend);
            List<int> IdFriends = new List<int>();
            foreach (var friend in ListIdFriends)
            {
                IdFriends.Add(friend.IdSign);
            }
            return IdFriends;
        }

        public IEnumerable<DalPerson> Search(string name)
        {
            var persons = (from person in context.People where person.Login.StartsWith(name) select person); 
            List<DalPerson> ListFriends = new List<DalPerson>();
            foreach (var person in persons)
            {
                    DalPerson vm = new DalPerson();
                    vm.Id = person.IdPeople;
                    vm.EmailAddress = person.EmailAddress;
                    vm.FirstName = person.FirstName;
                    vm.IdRole = person.IdRole;
                    vm.LastName = person.LastName;
                    vm.Login = person.Login;
                    vm.MobilPhone = person.MobilPhone;
                    ListFriends.Add(vm);
            }
            RecordRepository rep = new RecordRepository();
            IEnumerable<RecordDal> reclist = rep.GetAll();
            foreach (var friend in ListFriends)
            {
                foreach (var record in reclist)
                {
                    if (record.IdPeople == friend.Id)
                    {
                        friend.CountRecord++;
                    }
                }
              
            }
            return ListFriends;
        }
        public void Unsubscribe(int idOwner, int idGuest)
        {

            var entity = (from record in context.Signs where record.IdOwner == idOwner && record.IdSign == idGuest select record).FirstOrDefault();
                context.Signs.Remove(entity);
                context.SaveChanges();
               
        }
       
    }
    }

