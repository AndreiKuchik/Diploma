
using BL.Interface.Services;
using BL.Services;
using DAL.Concrete;
using DAL.Interface.Repository;
using Ninject;
using Ninject.Web.Common;
using ORM;
using System.Data.Entity;

namespace DependencyResolver
{
    public static class ResolverModule
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            Configure(kernel, true);
        }
        //public static void ConfigurateResolverConsole(this IKernel kernel)
        //{
        //    Configure(kernel, false);
        //}
        private static void Configure(IKernel kernel, bool isWeb)
        {
          
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
                kernel.Bind<DbContext>().To<ORM.LocalDatabaseBlogEntities>().InRequestScope();

                //kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
                //kernel.Bind<DbContext>().To<ORM.LocalDatabaseBlogEntities>().InSingletonScope();
#region Services
                kernel.Bind<IUserServices>().To<UserServices>();
                kernel.Bind<ICommentService>().To<CommentServices>();
                kernel.Bind<IThemeServices>().To<ThemeServices>();
                kernel.Bind<IRecordService>().To<RecordServices>();
                kernel.Bind<IResourceServices>().To<ResourceServices>();
#endregion
#region Repository
                kernel.Bind<ISourceRepository>().To<SourceRepository>();
                kernel.Bind<IRecordRepository>().To<RecordRepository>();
                kernel.Bind<ICommentRepository>().To<CommentRepository>();
                kernel.Bind<IUserRepository>().To<UserRepository>();
                kernel.Bind<IThemeRepository>().To<ThemeRepository>();
#endregion
        }
    }
}
