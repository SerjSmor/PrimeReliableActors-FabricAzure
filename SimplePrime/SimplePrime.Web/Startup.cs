using System.Web.Http;
using Owin;
using global::Owin;

namespace SimplePrime.Web
{
    public static class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public static void ConfigureApp(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();

            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller ="Values" , id = RouteParameter.Optional }
            );

            //PhysicalFileSystem physicalFileSystem = new PhysicalFileSystem(@".\wwwroot");

            //FileServerOptions fileOptions = new FileServerOptions();

            //fileOptions.EnableDefaultFiles = true;
            //fileOptions.RequestPath = PathString.Empty;
            //fileOptions.FileSystem = physicalFileSystem;
            //fileOptions.DefaultFilesOptions.DefaultFileNames = new[] { "index.html" };
            //fileOptions.StaticFileOptions.FileSystem = physicalFileSystem;
            //fileOptions.StaticFileOptions.ServeUnknownFileTypes = true;

            appBuilder.UseWebApi(config);
        }
    }
}
