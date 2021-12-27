using Autofac;
using StockData.Worker.Logic.Contexts;
using StockData.Worker.Logic.Repositories;
using StockData.Worker.Logic.Services;
using StockData.Worker.Logic.UnitOfWorks;
using System;

namespace StockData.Worker.Logic
{
    public class LogicModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        public LogicModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StockDataWorkerContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<StockDataWorkerContext>().As<IStockDataWorkerContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();
            builder.RegisterType<CompanyRepository>().As<ICompanyRepository>().InstancePerLifetimeScope();
            builder.RegisterType<StockPriceRepository>().As<IStockPriceRepository>().InstancePerLifetimeScope();
            builder.RegisterType<StockDataWorkerUnitOfWork>().As<IStockDataWorkerUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<CompnayService>().As<ICompnayService>().InstancePerLifetimeScope();
            builder.RegisterType<StockPriceService>().As<IStockPriceService>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
