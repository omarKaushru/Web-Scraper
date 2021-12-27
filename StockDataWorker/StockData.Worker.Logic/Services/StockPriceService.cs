using AutoMapper;
using StockData.Worker.Logic.BusinessObjects;
using StockData.Worker.Logic.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Worker.Logic.Services
{
    public class StockPriceService : IStockPriceService
    {
        private readonly IStockDataWorkerUnitOfWork _stockDataWorkerUnitOfWork;
        private readonly IMapper _mapper;
        public StockPriceService(IStockDataWorkerUnitOfWork stockDataWorkerUnitOfWork, IMapper mapper)
        {
            _stockDataWorkerUnitOfWork = stockDataWorkerUnitOfWork;
            _mapper = mapper;
        }
        public void AddStockPrice(StockPrice stockPrice)
        {
            if(stockPrice!=null)
            {
                _stockDataWorkerUnitOfWork.StockPrice.Add(
                    _mapper.Map(stockPrice, new Entities.StockPrice())
                    );
                _stockDataWorkerUnitOfWork.Save();
            }
        }
    }
}
