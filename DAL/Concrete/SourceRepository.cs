using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Entity;
using DAL.Interface.Repository;
using ORM;

namespace DAL.Concrete
{
    public class SourceRepository:ISourceRepository
    {
        private readonly LocalDatabaseBlogEntities context = new LocalDatabaseBlogEntities();
        //private readonly LocalDatabaseBlogEntities1 context = new LocalDatabaseBlogEntities1();
        public void SaveResouce(SourceDal source)
        {

            //if (product.ProductID == 0)
            //{
            //    context.Products.Add(product);
            //}
            //else
            //{
                var sourse = new Resours()
                {
                    ImageMimeType = source.ImageMimeType,
                    Resourse = source.Resourse
                    
                };
                context.Resourses.Add(sourse);
                context.SaveChanges();
              
        }

        public SourceDal GetImage(int idResource)
        {
            try
            {

                var q = (from s in context.Resourses where s.IdResourse== idResource select s).FirstOrDefault();

                if (q != null)
                {

                    return new SourceDal()
                    {
                        IdResourse = q.IdResourse,
                        IdPeople = Convert.ToInt32(q.IdPeople),
                        IdRecord = Convert.ToInt32(q.IdPeople),
                        Resourse = q.Resourse,
                        ImageMimeType = q.ImageMimeType
                    };
                }
               
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
          
        }
    }
}
