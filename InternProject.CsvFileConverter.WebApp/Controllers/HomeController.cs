using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using InternProject.CsvFileConverter.Library.Extensions.Mapping;
using InternProject.CsvFileConverter.WebApp.Models;
using InternProject.CsvFileConverter.WebApp.WebApiConfig;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InternProject.CsvFileConverter.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly DealsApi api = new DealsApi();

        public async Task<IActionResult> Index()
        {
            var deals = new List<DealData>();
            var client = api.Initial();
            var res = await client.GetAsync("api/v1/Deals");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                deals = JsonConvert.DeserializeObject<List<DealData>>(result);
            }

            return View(deals);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        public async Task<IActionResult> Create(DealData data)
        {
            var res = new HttpResponseMessage();
            if (!ModelState.IsValid) return View(data);
            var client = api.Initial();

            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            res =  client.PostAsync("api/v1/Deals", content).Result;

            //if (res.IsSuccessStatusCode) return RedirectToAction("Index");

            return View(data);
        }

        public async Task<IActionResult> Edit(string id, DealData data)
        {

            if (id != data.V3DealId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                HttpClient client = api.Initial();

                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8,
                    "application/json");
                HttpResponseMessage res = client.PutAsync("api/student", content).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(data);
        }


        public async Task<IActionResult> Details()
        {
            return View();
        }

        public async Task<IActionResult> SendData()
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Delete()
        {
            throw new NotImplementedException();
        }
    }
}