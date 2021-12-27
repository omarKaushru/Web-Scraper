using StockData.Worker.Logic.BusinessObjects;
using StockData.Worker.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Worker.Insert
{
    public class InsertCompany
    {
        private readonly ICompnayService _compnayService;
        public InsertCompany(ICompnayService compnayService)
        {
            _compnayService = compnayService;
        }
        public void Create(Company company)
        {
            _compnayService.AddCompany(company);
        }

    }
}
