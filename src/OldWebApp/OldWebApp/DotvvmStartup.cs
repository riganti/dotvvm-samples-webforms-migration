using System;
using DotVVM.Framework.Configuration;
using DotVVM.Framework.ResourceManagement;
using Microsoft.Extensions.DependencyInjection;

namespace OldWebApp
{
    public class DotvvmStartup : IDotvvmStartup, IDotvvmServiceConfigurator
    {
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {
            ConfigureRoutes(config, applicationPath);
            ConfigureControls(config, applicationPath);
            ConfigureResources(config, applicationPath);
        }

        private void ConfigureRoutes(DotvvmConfiguration config, string applicationPath)
        {
            config.RouteTable.Add("Default", "", "Views/Default.dothtml");
            config.RouteTable.Add("About", "About", "Views/About.dothtml");
        }

        private void ConfigureControls(DotvvmConfiguration config, string applicationPath)
        {
        }

        private void ConfigureResources(DotvvmConfiguration config, string applicationPath)
        {
            config.Resources.Register("jquery", new ScriptResource()
            {
                Location = new UrlResourceLocation("~/Scripts/jquery-3.3.1.min.js"),
            });
            config.Resources.Register("bootstrap", new ScriptResource()
            {
                Location = new UrlResourceLocation("~/Scripts/bootstrap.min.js"),
                Dependencies = new[] { "jquery" }
            });
        }

        public void ConfigureServices(IDotvvmServiceCollection options)
        {
            options.AddDefaultTempStorages("Temp");
        }
    }
}