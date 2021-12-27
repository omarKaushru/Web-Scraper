using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using StockData.Worker.Insert;
using StockData.Worker.Logic.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Worker
{
    public class DataRetriever
    {
        private readonly InsertCompany _insertCompany;
        private readonly InsertStockPrice _insertStockPrice;
        private readonly ILogger<DataRetriever> _logger;
        public DataRetriever(ILogger<DataRetriever> logger, InsertCompany insertCompany, InsertStockPrice insertStockPrice)
        {
            _insertCompany = insertCompany;
            _insertStockPrice = insertStockPrice;
            _logger = logger;
        }
        public void DataModel()
        {
            var dataList = new List<string>();
            var html = @"https://www.dse.com.bd/latest_share_price_scroll_l.php";
            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);
            var query = from table in htmlDoc.DocumentNode.SelectNodes("//table").Where(z => z.HasClass("table")).Cast<HtmlNode>()
                        from row in table.SelectNodes("tr").Cast<HtmlNode>()
                        from cell in row.SelectNodes("td").Cast<HtmlNode>()
                        select new { CellText = cell.InnerText.Trim() };
            int c = 0;
            foreach (var item in query)
            {
                if (item.CellText.Contains("LTP - YCP"))
                    break;
                else
                {
                    dataList.Add(item.CellText.Trim());
                    c++;
                }
                if (c == 11)
                {
                    var bCompany = new Company();
                    var bStockPrice = new StockPrice();
                    bCompany.TradeCode = dataList[1];
                    bStockPrice.CompanyId = dataList[0];
                    bStockPrice.LastTradingPrice = dataList[2];
                    bStockPrice.High = dataList[3];
                    bStockPrice.Low = dataList[4];
                    bStockPrice.ClosePrice = dataList[5];
                    bStockPrice.YesterdayClosePrice = dataList[6];
                    bStockPrice.Change = dataList[7];
                    bStockPrice.Trade = dataList[8];
                    bStockPrice.Value = dataList[9];
                    bStockPrice.Volume = dataList[10];
                    _insertCompany.Create(bCompany);
                    _insertStockPrice.Create(bStockPrice);
                    c = 0;
                    dataList.Clear();
                }
            }
            _logger.LogInformation("Data Inserted:");
        }
    }
}
