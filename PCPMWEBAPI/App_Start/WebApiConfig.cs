using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors; //for webapi cors

namespace PCPMWEBAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            EnableCorsAttribute cors = new EnableCorsAttribute("*","*","*");
            /*
             1. "*" : 1st star in EnableCorsAttribute is for website allow only this site "www.example.com" other are block, for allow all use "*"
             2. "*" : 2nd star is for list of headers that are supported by the resource. for example, "accept,content-type,origin"
                will only allow these 3 headers. Use "*"to allow all. Use the null or empty string to allow none.
            3. "*" : 3rd star for that are supported by the resource. 
                For example “GET, POST” only allows Get and Post and blocks the rest of the methods.
            Use "*" to allow all. Use a null or empty string to allow none
             */
            config.EnableCors(cors);

           
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
