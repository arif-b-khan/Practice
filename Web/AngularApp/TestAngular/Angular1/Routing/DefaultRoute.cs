// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRoute.cs" company="Microsoft">
//   Copyright � 2015 Microsoft
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace App.Angular1.Routing
{
    using System.Web.Routing;

    public class DefaultRoute : Route
    {
        public DefaultRoute()
            : base("{*path}", new DefaultRouteHandler())
        {
            this.RouteExistingFiles = false;
        }
    }
}
