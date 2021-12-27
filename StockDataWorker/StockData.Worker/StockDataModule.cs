using Autofac;
using Microsoft.Extensions.Configuration;
using StockData.Worker.Insert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Worker
{
    public class StockDataModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        private readonly IConfiguration _configuration;

        public StockDataModule(string connectionStringName, string migrationAssemblyName,
            IConfiguration configuration)
        {
            _connectionString = connectionStringName;
            _migrationAssemblyName = migrationAssemblyName;
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InsertCompany>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<InsertStockPrice>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<DataRetriever>().AsSelf().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
