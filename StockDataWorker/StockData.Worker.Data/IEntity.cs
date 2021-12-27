using System;
using System.Collections.Generic;
using System.Text;

namespace StockData.Worker.Data
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
