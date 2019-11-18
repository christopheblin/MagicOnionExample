using Grpc.Core;
using MagicOnion.Client;
using MagicOnion.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service1Def;
using Service2Def;
using System;
using System.Threading.Tasks;

namespace Service2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            GrpcEnvironment.SetLogger(new Grpc.Core.Logging.ConsoleLogger());

            await MagicOnionHost.CreateDefaultBuilder()
                .ConfigureHostConfiguration(configHost =>
                {
                    configHost.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton(MyFirstServiceClientFactory.Build());
                    services.AddSingleton<IMySecondService, MySecondService>();
                })
                .UseMagicOnion()
                .RunConsoleAsync();
        }
    }
}
