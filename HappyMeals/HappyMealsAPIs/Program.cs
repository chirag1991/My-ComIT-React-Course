using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HappyMealsAPIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();

                });
    }
}

//--------in built code------------------------------------------------
//var builder = webapplication.createbuilder(args);

// add services to the container.

//builder.services.addcontrollers();
// learn more about configuring swagger/openapi at https://aka.ms/aspnetcore/swashbuckle
//builder.services.addendpointsapiexplorer();
//builder.services.addswaggergen();
//var app = builder.build();
// configure the http request pipeline.
//if (app.environment.isdevelopment())
//{
//    app.useswagger();
//    app.useswaggerui();
//}

//app.useauthorization();

//app.mapcontrollers();

//app.run();
//--------------------------------------------------------