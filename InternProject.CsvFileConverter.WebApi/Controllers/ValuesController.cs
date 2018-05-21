using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternProject.CsvFileConverter.Library.Extensions.Mapping;
using InternProject.CsvFileConverter.Library.Stores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InternProject.CsvFileConverter.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IDbContextFactory _dbContextFactory;

        public ValuesController(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
        }

        [HttpGet]
        public IEnumerable<DealData> GetValues()
        {
            return _dbContextFactory.Create().Set<DealData>();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get()
        {
            using (var db = _dbContextFactory.Create())
            {
                foreach (var dealData in db.Set<DealData>())
                {
                    var response
                        = db.Set<DealData>().Find(dealData.V3DealId);

                    return Ok(response);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(DealData value)
        {
            using (var db = _dbContextFactory.Create())
            {
                var response = new DealData();
                db.Database.EnsureCreated();
                foreach (var dealData in db.Set<DealData>())
                {
                    response = db.Set<DealData>()
                        .AsNoTracking()
                        .FirstOrDefault(d => value.V3DealId == dealData.V3DealId);

                    if (response == null)
                        db.Set<DealData>().Add(dealData);
                    else
                        db.Set<DealData>().Update(dealData);


                }

                db.SaveChanges();
                return Ok(response);
            }
        }

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}