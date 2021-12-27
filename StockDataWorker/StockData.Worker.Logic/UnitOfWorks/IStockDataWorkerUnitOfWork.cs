using StockData.Worker.Data;
using StockData.Worker.Logic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Worker.Logic.UnitOfWorks
{
    public interface IStockDataWorkerUnitOfWork : IUnitOfWork
    {
        public ICompanyRepository Company { get; }
        public IStockPriceRepository StockPrice { get; }
    }
}
