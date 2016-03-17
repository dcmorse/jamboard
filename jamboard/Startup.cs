using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(jamboard.Startup))]
namespace jamboard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
