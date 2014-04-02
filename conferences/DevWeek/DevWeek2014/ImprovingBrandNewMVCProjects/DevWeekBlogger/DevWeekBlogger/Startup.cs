using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DevWeekBlogger.Startup))]
namespace DevWeekBlogger
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
