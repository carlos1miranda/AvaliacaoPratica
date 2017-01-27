using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AvaliacaoPratica.Startup))]
namespace AvaliacaoPratica
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
