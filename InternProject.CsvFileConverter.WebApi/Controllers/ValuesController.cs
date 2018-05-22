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
        public async Task<IActionResult> Get(string id)
        {
            using (var db = _dbContextFactory.Create())
            {
                var dealData = await db.Set<DealData>().FindAsync(id);
                if (dealData== null) return NotFound();

                return Ok(dealData);
            }
        }

        [HttpPost("{V3DealId}")]
        public async Task<IActionResult> Post(DealData value)
        {
            using (var db = _dbContextFactory.Create())
            {
                db.Database.EnsureCreated();

                var loaded = await db.Set<DealData>()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(d => d.V3DealId == value.V3DealId);

                if (loaded == null)
                    db.Set<DealData>().Add(value);
                else
                    db.Set<DealData>().Update(value);

                db.SaveChanges();
                return Ok(db);
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