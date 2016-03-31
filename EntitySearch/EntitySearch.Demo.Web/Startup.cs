using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EntitySearch.Startup))]
namespace EntitySearch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
