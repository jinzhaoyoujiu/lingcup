using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LinJiaYou.Startup))]
namespace LinJiaYou
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
