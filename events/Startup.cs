using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(events.Startup))]
namespace events
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
