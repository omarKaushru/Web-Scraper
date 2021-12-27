using Microsoft.EntityFrameworkCore;
using StockData.Worker.Data;
using StockData.Worker.Logic.Contexts;
using StockData.Worker.Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Worker.Logic.Repositories
{
    public class CompanyRepository : Repository<Company, int>, ICompanyRepository
    {
        public CompanyRepository(IStockDataWorkerContext context)
        : base((DbContext)context)
        {
        }
    }
}
