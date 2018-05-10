using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternProject.CsvFileConverter.Library.Extensions.Mapping;
using InternProject.CsvFileConverter.Library.Stores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace InternProject.CsvFileConverter.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly DealDataDbContext _dataContext;

        public ValuesController(DealDataDbContext dataContext)
        {
            _dataContext = dataContext;
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

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

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
