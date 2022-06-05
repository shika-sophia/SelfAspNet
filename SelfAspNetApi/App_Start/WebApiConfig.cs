/*
 *@modified SampleCode/ClientCallJs.aspx.cs 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SelfAspNetApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API の設定およびサービス

            // Web API ルート
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "SampleCode/api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
