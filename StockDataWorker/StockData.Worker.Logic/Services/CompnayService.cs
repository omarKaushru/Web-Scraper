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
    public class CompnayService : ICompnayService
    {
        private readonly IStockDataWorkerUnitOfWork _stockDataWorkerUnitOfWork;
        private readonly IMapper _mapper;
        public CompnayService(IStockDataWorkerUnitOfWork stockDataWorkerUnitOfWork, IMapper mapper)
        {
            _stockDataWorkerUnitOfWork = stockDataWorkerUnitOfWork;
            _mapper = mapper;
        }
        public void AddCompany(Company company)
        {
            if(company!=null)
            {
                _stockDataWorkerUnitOfWork.Company.Add(
                    _mapper.Map(company, new Entities.Company())
                    );
                _stockDataWorkerUnitOfWork.Save();
            }
        }
    }
}
