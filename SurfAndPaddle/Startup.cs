using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SurfAndPaddle.Startup))]
namespace SurfAndPaddle
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
          
            ConfigureAuth(app);
        }
    }
}
