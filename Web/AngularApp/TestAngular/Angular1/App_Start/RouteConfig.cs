// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RouteConfig.cs" company="Microsoft">
//   Copyright © 2015 Microsoft
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace App.Angular1
{
    using System.Web.Routing;

    using App.Angular1.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Add("Default", new DefaultRoute());
        }
    }
}
