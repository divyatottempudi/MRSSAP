using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MRSSApp.Startup))]
namespace MRSSApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
