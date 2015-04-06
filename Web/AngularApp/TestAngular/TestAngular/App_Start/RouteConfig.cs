// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RouteConfig.cs" company="Microsoft">
//   Copyright © 2015 Microsoft
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace App.TestAngular
{
    using System.Web.Routing;

    using App.TestAngular.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Add("Default", new DefaultRoute());
        }
    }
}
