using StockData.Worker.Logic.BusinessObjects;
using StockData.Worker.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Worker.Insert
{
    public class InsertStockPrice
    {
        private readonly IStockPriceService _stockPriceService;
        public InsertStockPrice(IStockPriceService stockPriceService)
        {
            _stockPriceService = stockPriceService;
        }

        public void Create(StockPrice stockPrice)
        {        
            _stockPriceService.AddStockPrice(stockPrice);
        }
    }
}
