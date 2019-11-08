using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CoreConfigurationSettingMVC
{
    public class Program
    {
       // private static Dictionary<string, string> configDict = new Dictionary<string, string>();

        public static void Main(string[] args)
        {
            //configDict.Add("Projector", "EPSON");
            //configDict.Add("Laptop", "DELL");
            
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            //.ConfigureAppConfiguration(config=>
            //{
            //    config.SetBasePath(Directory.GetCurrentDirectory())
            //    .AddXmlFile("MySettingsXML.xml", optional: true)
            //    .AddJsonFile("MySettingsJson.json", optional: true)
            //    .AddInMemoryCollection(configDict);
            //})
            .UseStartup<Startup>();
    }
}
