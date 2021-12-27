using HtmlAgilityPack;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockData.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly DataRetriever _dataRetriever;
        public Worker(ILogger<Worker> logger, DataRetriever dataRetriever)
        {
            _logger = logger;
            _dataRetriever = dataRetriever;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var html = @"https://www.dse.com.bd/latest_share_price_scroll_l.php";
                HtmlWeb web = new HtmlWeb();
                var htmlDoc = web.Load(html);
                bool status = false;
                var statusQuery = from div in htmlDoc.DocumentNode.SelectNodes("//div").Where(d => d.HasClass("HeaderTopMobile")).Cast<HtmlNode>()
                                  from span in div.SelectNodes("span").Cast<HtmlNode>().ToList()
                                  select new { s = span.InnerText };
                foreach (var item in statusQuery)
                {
                    if (item.s.Trim().ToLower() == "open")
                        status = true;
                }
                if (status)
                {
                    _dataRetriever.DataModel();
                }
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(60000, stoppingToken);
            }
        }
    }
}
