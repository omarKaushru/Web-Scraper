using AutoMapper;
using EO = StockData.Worker.Logic.Entities;
using BO = StockData.Worker.Logic.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Worker.Logic.Profiles
{
    public class LogicProfile : Profile
    {
        public LogicProfile()
        {
            CreateMap<EO.Company, BO.Company>().ReverseMap();
            CreateMap<EO.StockPrice, BO.StockPrice>().ReverseMap();
        }

    }
}
