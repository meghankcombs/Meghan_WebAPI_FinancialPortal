using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Meghan_CF_FinancialPortal.Startup))]
namespace Meghan_CF_FinancialPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
