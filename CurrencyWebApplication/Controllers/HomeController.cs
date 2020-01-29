using CurrencyWebApplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CurrencyWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var webClient = new System.Net.WebClient())
            {
                webClient.Encoding = Encoding.UTF8;
                var rates = webClient.DownloadString("https://api.exchangeratesapi.io/latest?base=TRY");
                ExchangeModel exchangeData = JsonConvert.DeserializeObject<ExchangeModel>(rates);
                ViewBag.exchangeData = exchangeData;
                var currencies = webClient.DownloadString("https://openexchangerates.org/api/currencies.json");
                CurrencyModel currencyData = JsonConvert.DeserializeObject<CurrencyModel>(currencies);
                ViewBag.currencyData = currencyData;
                
            }

            return View();
        }
        [HttpGet]
        public ActionResult Result()
        {
            var code = Request.QueryString["value"];
            var webClient = new System.Net.WebClient();
            var rates = webClient.DownloadString("https://api.exchangeratesapi.io/latest?base="+code);
            ExchangeModel exchangeData = JsonConvert.DeserializeObject<ExchangeModel>(rates);
            ViewBag.exchangeData = exchangeData;
            ViewBag.code = code;

            var currencies = webClient.DownloadString("https://openexchangerates.org/api/currencies.json");
            CurrencyModel currencyData = JsonConvert.DeserializeObject<CurrencyModel>(currencies);
            ViewBag.currencyData = currencyData;
            return PartialView("Partials/View");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}