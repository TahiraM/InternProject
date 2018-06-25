using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using InternProject.CsvFileConverter.Library.Extensions.Mapping;
using InternProject.CsvFileConverter.WebApp.Models;
using InternProject.CsvFileConverter.WebApp.WebApiConfig;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static System.String;

namespace InternProject.CsvFileConverter.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly DealsApi _api = new DealsApi();

        public async Task<IActionResult> Index()
        {
            var deals = new List<DealData>();
            var client = _api.Initial();
            var res = await client.GetAsync("api/v1/Deals");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                deals = JsonConvert.DeserializeObject<List<DealData>>(result);
            }

            return View(deals);
        }

        [HttpGet]
        public async Task<IActionResult> Create(string id)
        {
            if (id == Empty) throw new ArgumentNullException();
            try
            {
                var response = await _api.Initial().GetAsync("api/v1/Deals/" + id);
                var result = response.Content.ReadAsStringAsync().Result;
                return View(response.Content.ReadAsAsync<DealData>().Result);
                
            }
            catch (DataException )
            {
                ModelState.AddModelError("",
                    "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }

            return View("Create");
        }


        public async Task<IActionResult> Create([Bind(
                "EFrontDealId, V3DealId,DealName,V3CompanyId,V3CompanyName,SectorId, Sector," +
                "CountryId,Country,TransactionTypeId,TransactionType,TransactionFees,OtherFees, " +
                "Currency, ActiveInActive,ExitDate ")]
            DealData data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _api.Initial().PostAsync("api/v1/Deals", data, new JsonMediaTypeFormatter());
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("",
                    "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == Empty) throw new ArgumentNullException();
            try
            {
                var response = await _api.Initial().DeleteAsync("api/v1/Deals/" + id);
                var result = response.Content.ReadAsStringAsync().Result;
                return RedirectToAction("Index");

            }
            catch (DataException)
            {
                ModelState.AddModelError("",
                    "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }

            return View("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}