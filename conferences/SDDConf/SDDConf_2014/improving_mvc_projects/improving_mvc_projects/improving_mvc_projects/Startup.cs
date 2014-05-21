using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(improving_mvc_projects.Startup))]
namespace improving_mvc_projects
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
