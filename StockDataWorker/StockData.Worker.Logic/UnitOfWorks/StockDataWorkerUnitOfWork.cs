using Microsoft.EntityFrameworkCore;
using StockData.Worker.Data;
using StockData.Worker.Logic.Contexts;
using StockData.Worker.Logic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Worker.Logic.UnitOfWorks
{
    public class StockDataWorkerUnitOfWork : UnitOfWork, IStockDataWorkerUnitOfWork
    {
        public ICompanyRepository Company { get; set; }
        public IStockPriceRepository StockPrice { get; set; }
        public StockDataWorkerUnitOfWork(IStockDataWorkerContext context, ICompanyRepository company, IStockPriceRepository stockPrice)
            : base((DbContext)context)
        {
            Company = company;
            StockPrice = stockPrice;
        }
    }
}
