using System.Collections.Generic;
using InternProject.CsvFileConverter.Library.Extensions.Mapping;
using InternProject.CsvFileConverter.Library.Stores;
using Microsoft.AspNetCore.Mvc;

namespace InternProject.CsvFileConverter.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly DealDataDbContext _dataContext;

        public ValuesController()
        {
            _dataContext = new DealDataDbContext();
            var loaded = _dataContext.Set<DealData>();
            if (loaded == null)
                _dataContext.Set<DealData>().Add(new DealData
                {
                    V3DealId = "helloo",
                    Country = "boo"
                });
            else
                _dataContext.Set<DealData>().Update(new DealData
                {
                    V3DealId = "helloo",
                    Country = "boo"
                });
        }

        [HttpGet]
        public void GetDefault()
        {
            var success = true;
        }

        [HttpGet("{V3DealId}", Name = "GetData")]
        public IEnumerable<DealData> Get()
        {
            using (var db = new DealDataDbContext())
            {
                return db.Set<DealData>();
            }
        }

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

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