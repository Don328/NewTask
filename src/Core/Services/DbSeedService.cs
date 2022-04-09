using Microsoft.Extensions.Hosting;
using NewTask.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTask.Core.Services
{
    internal class DbSeedService : BackgroundService
    {
        private readonly InMemDbContext inMemDb;
        private readonly Seed seed;

        public DbSeedService(
            InMemDbContext inMemDb,
            Seed seed)
        {
            this.inMemDb = inMemDb;
            this.seed = seed;
            ExecuteAsync(new CancellationToken()).Wait();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                await SeedInMemDb(stoppingToken);
            }
        }

        private async Task SeedInMemDb(CancellationToken token)
        {
            if (!inMemDb.Opera.Any())
            {
                var opera = seed.SeedOpera();
                await inMemDb.Opera.AddRangeAsync(opera);
            }

            if (!inMemDb.Notas.Any())
            {
                var notas = seed.SeedNotas();
                await inMemDb.Notas.AddRangeAsync(notas);
            }

            await inMemDb.SaveChangesAsync();
            
            await Task.CompletedTask;

            await StopAsync(token);
        }
    }
}
