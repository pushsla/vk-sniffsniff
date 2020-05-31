using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace echobot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                using (FileStream fs = new FileStream(Auth.Dumpfile, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    AuthTransfer authtransfer = (AuthTransfer) formatter.Deserialize(fs);
                    authtransfer.SetAuth();
                    Console.WriteLine($"::==>:: AUTH: {Auth.Dumpfile} file was loaded! Epoch: {Auth.Epoch}");
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"::==>:: No AUTH: {Auth.Dumpfile} file was found! Configure authentication!");
            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}