using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QualityOrganizationWebsite.Startup))]
namespace QualityOrganizationWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
