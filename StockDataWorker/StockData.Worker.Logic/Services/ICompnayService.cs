using StockData.Worker.Logic.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Worker.Logic.Services
{
    public interface ICompnayService
    {
        void AddCompany(Company company);
    }
}
