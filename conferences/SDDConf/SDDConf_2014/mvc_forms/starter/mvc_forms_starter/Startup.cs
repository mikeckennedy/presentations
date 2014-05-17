using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvc_forms_starter.Startup))]
namespace mvc_forms_starter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
