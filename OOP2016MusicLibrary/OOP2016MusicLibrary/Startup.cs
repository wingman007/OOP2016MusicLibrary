using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OOP2016MusicLibrary.Startup))]
namespace OOP2016MusicLibrary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
