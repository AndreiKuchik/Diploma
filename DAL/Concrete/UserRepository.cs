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

        public void Update(Interface.Entity.DalPerson entity)
        {
            throw new NotImplementedException();
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

        public DalPerson Login(DalPerson person)
        {
            try
            {
                
                var q = (from s in context.People where s.Login.Equals(person.Login) && s.Password.Equals(person.Password) select s).FirstOrDefault();

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
                person.Id = 0;
                return person;
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


        public IEnumerable<int> ToSubscribe(int idOwner, int idUser)
        {
                var sign = new Sign()
                {
                    IdSign = idUser,
                    IdOwner = idOwner


                };
                context.Signs.Add(sign);
                context.SaveChanges();

                var ListIdFriends = (from friend in context.Signs where friend.IdOwner == idOwner select friend);
                List<int> IdFriends = new List<int>();
                foreach (var friend in ListIdFriends)
                {
                    IdFriends.Add(friend.IdOwner);
                }
            return IdFriends;

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
       
    }
    }

