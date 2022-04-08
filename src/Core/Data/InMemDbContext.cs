using Microsoft.EntityFrameworkCore;
using NewTask.Core.Data.ModelBuilders;
using NewTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTask.Core.Data
{
    internal class InMemDbContext : DbContext
    {
        private const string connectionString = "Data Source=:memory:";
        
        internal DbSet<_Nota> Notas { get; set; }
        internal DbSet<_Opus> Opera { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new NotaModelBuilder()
                .Configure(builder.Entity<_Nota>());
            
            new OpusModelBuilder()
                .Configure(builder.Entity<_Opus>());
        }   
    }
}
