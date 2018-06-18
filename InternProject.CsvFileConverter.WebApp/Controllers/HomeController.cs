using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using InternProject.CsvFileConverter.Library.Extensions.Mapping;
using InternProject.CsvFileConverter.WebApp.Helper;
using Microsoft.AspNetCore.Mvc;
using InternProject.CsvFileConverter.WebApp.Models;
using Newtonsoft.Json;

namespace InternProject.CsvFileConverter.WebApp.Controllers
{
    public class HomeController : Controller
    {
        DealsApi api = new DealsApi();
        public async Task <IActionResult> Index()
        {
            List<DealData> dealdata = new List<DealData>();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.GetAsync("api/v1/Deals");

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                dealdata = JsonConvert.DeserializeObject<List<DealData>>(result);
            }
            return View(dealdata);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
