using HtmlAgilityPack;
using RubberThaiReader.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RubberThaiReader.Web.Controllers
{
    public class HomeController : Controller
    {
        public async Task<string> Index() {

            string rubberUrl = "http://www.rubberthai.com/price/today%20price/ebay_price.htm";
            using (var client = new HttpClient()) {
                var response = await client.GetAsync(rubberUrl);
                response.EnsureSuccessStatusCode();

                var htmlStream = await response.Content.ReadAsStreamAsync();

                StringBuilder sb = new StringBuilder();

                HtmlDocument doc = new HtmlDocument();
                doc.Load(htmlStream, Encoding.GetEncoding("windows-874"));

                RubberPrice price = new RubberPrice();
                string rawDate = doc.DocumentNode.SelectSingleNode("//body/table/tr[2]/td[2]").InnerText;
                price.RawDate = rawDate.Replace("Date", "").Replace(":", "").Trim();
                price.Date = DateTime.ParseExact(price.RawDate, "MMMM d,yyyy", CultureInfo.InvariantCulture);

                var ussList = new List<Uss>();
                foreach (HtmlNode ussRow in doc.DocumentNode.SelectNodes("//body/table/tr[4]/td/table/tr").Skip(2)) {

                    var names = ussRow.SelectSingleNode("td[1]").InnerText.Trim();
                    var price1 = ussRow.SelectSingleNode("td[2]").InnerText.Trim();
                    var price2 = ussRow.SelectSingleNode("td[3]").InnerText.Trim();
                    var price3 = ussRow.SelectSingleNode("td[4]").InnerText.Trim();
                    var price4 = ussRow.SelectSingleNode("td[5]").InnerText.Trim();
                    var price5 = ussRow.SelectSingleNode("td[6]").InnerText.Trim();

                    var market = new Uss();

                    market.RubberMarketEn = names;
                    market.RubberMarketTh = names;

                    decimal _price;
                    if (decimal.TryParse(price1, out _price)) { market.Price1 = _price; }
                    if (decimal.TryParse(price2, out _price)) { market.Price2 = _price; }
                    if (decimal.TryParse(price3, out _price)) { market.Price3 = _price; }
                    if (decimal.TryParse(price4, out _price)) { market.Price4 = _price; }
                    if (decimal.TryParse(price5, out _price)) { market.Price5 = _price; }

                    ussList.Add(market);
                }

                price.UssPrices = ussList;

                sb.AppendFormat("<div style='padding: 20px; background-color: #ccc;'>{0}</div>", price.ToString());

                return sb.ToString();
            }
        }
    }
}