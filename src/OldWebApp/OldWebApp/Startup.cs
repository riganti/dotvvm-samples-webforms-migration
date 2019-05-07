using System;
using System.Threading.Tasks;
using System.Web.Hosting;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(OldWebApp.Startup))]

namespace OldWebApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseDotVVM<DotvvmStartup>(HostingEnvironment.ApplicationPhysicalPath);
        }
    }
}
