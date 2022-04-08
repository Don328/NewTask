using Microsoft.EntityFrameworkCore;
using NewTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTask.Core.Data
{
    public class InMemDbContext : DbContext
    {
        private const string connectionString = "Data Source=:memory:";
        
        public DbSet<_Nota> Notas { get; set; }
        public DbSet<_Opus> Opera { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(connectionString);
        }
    }
}
