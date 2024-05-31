using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(cellphonesweb.Startup))]
namespace cellphonesweb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
