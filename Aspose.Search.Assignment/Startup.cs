using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Aspose.Search.Assignment.Startup))]
namespace Aspose.Search.Assignment
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
