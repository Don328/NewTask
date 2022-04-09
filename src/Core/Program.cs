using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore.Sqlite;
using NewTask.Core.Data;
using NewTask.Core.Mappers;
using NewTask.Core.Data.Fixtures;
using NewTask.Core.Services;
using NewTask.Core.Interfaces;
using NewTask.Core.Output;

namespace NewTask.Core
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            
        }

        internal static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services
                        .AddDbContext<InMemDbContext>()
                        .AddTransient<Seed>()
                        .AddHostedService<DbSeedService>()
                        .AddTransient<OpusFixture>()
                        .AddTransient<NotaFixture>()
                        .AddTransient<OpusMapper>()
                        .AddTransient<NotaMapper>()
                        .AddTransient<IOutputNotas, NotaOutput>()
                        .AddTransient<IOutputOpera, OpusOutput>();
                });
    }
}