using Microsoft.EntityFrameworkCore;
using StockData.Worker.Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Worker.Logic.Contexts
{
    public class StockDataWorkerContext : DbContext ,IStockDataWorkerContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        public StockDataWorkerContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<StockPrice> StockPrices{ get; set; }
    }
}
