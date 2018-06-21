using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternProject.CsvFileConverter.Library.Core;
using InternProject.CsvFileConverter.Library.Extensions.Mapping;
using InternProject.CsvFileConverter.Library.Interfaces.Database.Interfaces;
using InternProject.CsvFileConverter.Library.Stores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InternProject.CsvFileConverter.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    public class DealsController : Controller
    {
        private readonly ICsvToJsonConverter _csvToJsonConverter;
        private readonly IDbContextFactory _dbContextFactory;
        private readonly IDealDataRepository _dealDataRepository;

        public DealsController(
            IDbContextFactory dbContextFactory,
            IDealDataRepository dealDataRepository,
            ICsvToJsonConverter csvToJsonConverter)
        {
            _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
            _dealDataRepository = dealDataRepository ?? throw new ArgumentNullException(nameof(dealDataRepository));
            _csvToJsonConverter = csvToJsonConverter ?? throw new ArgumentNullException(nameof(csvToJsonConverter));
        }

        [HttpGet]
        public Task<IEnumerable<DealData>> Get()
        {
            return _dealDataRepository.GetListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleDeal(string id)
        {
            var dealData = await _dealDataRepository.GetAsync(id);
            if (dealData == null) return NotFound();

            return Ok(dealData);
        }

        [HttpPost]
        public async Task<IActionResult> PostNewDealData([FromBody] DealData dealData)
        {
            if (dealData == null) throw new ArgumentNullException(nameof(dealData));

            var result = (await _dealDataRepository.SaveManyAsync(new[] {dealData})).ToList();
            if (result.Count != 1)
                return BadRequest();

            return Ok(result.First());
        }

        [HttpPost("{path}")]
        public void UploadFile([FromBody] string path)
        {
            _csvToJsonConverter.Convert(path);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] string id)
        {
            using (var db = _dbContextFactory.Create())
            {
                db.Database.EnsureCreated();

                var loaded = await db.Set<DealData>()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(d => d.V3DealId == id);

                if (loaded == null) return NotFound();
                db.Remove(loaded);
                return Ok(db.SaveChanges());
            }
        }
    }
}