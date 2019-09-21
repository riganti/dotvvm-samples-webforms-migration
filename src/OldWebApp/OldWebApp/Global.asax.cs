using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using OldWebApp.Model;

namespace OldWebApp
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            Database.SetInitializer(new AppDbInitializer());

            RouteTable.Routes.MapPageRoute("Default", "", "~/Default.aspx");
            RouteTable.Routes.MapPageRoute("About", "About", "~/About.aspx");
        }
    }
}