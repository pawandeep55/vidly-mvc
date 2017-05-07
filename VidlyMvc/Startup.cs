using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidlyMvc.Startup))]
namespace VidlyMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
