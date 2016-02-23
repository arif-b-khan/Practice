using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using Owin;

namespace KatanaExample
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        string uri = "http://localhost:8080";
    //        using (WebApp.Start<StartUp>(uri))
    //        {
    //            Console.WriteLine("Started!");
    //            Console.WriteLine("Press any key to stop");
    //            Console.ReadLine();
    //        }
    //    }
    //}
    //[assembly: OwinStartup("TestStartup", typeof(KatanaExample.MyStartup))]
    public class MyStartup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(async (env, next) =>
            {
                Console.WriteLine("Request : " + env.Request.Path);
                await next();
                Console.WriteLine("Response: " + env.Response.StatusCode);
            });
            
            ConfigureWebApi(app); //add comment from jan release

            app.UseHelloComponent();
        }

        public void ConfigureWebApi(IAppBuilder app)
        {
            HttpConfiguration httpConfig = new HttpConfiguration();
            httpConfig.Routes.MapHttpRoute("Default", "api/{controller}/{id}", new {id = RouteParameter.Optional});
            app.UseWebApi(httpConfig);
        }
    }

    public static class AppBuilderHelloExtension
    {
        public static void UseHelloComponent(this IAppBuilder app)
        {
            app.Use<HelloWorldComponent>();
        }
    }

    public class HelloWorldComponent
    {
        Func<IDictionary<string, object>, Task> _next;
        public HelloWorldComponent(Func<IDictionary<string, object>, Task> next)
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            var stream = environment["owin.ResponseBody"] as Stream;
            using (var strWriter = new StreamWriter(stream))
            {
                await strWriter.WriteAsync("Hello!!");
            }
        }
    }
}
