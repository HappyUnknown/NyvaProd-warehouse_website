using NyvaProdBC.Entity.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace NyvaProdBC
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Код, выполняемый при запуске приложения
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //System.Data.Entity.Database.SetInitializer<Entity.Contexts.NyvaUserContext>(null);
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<NyvaUserContext>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<GoodContext>());
        }
    }
}