using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PLnew.Startup))]
namespace PLnew
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
