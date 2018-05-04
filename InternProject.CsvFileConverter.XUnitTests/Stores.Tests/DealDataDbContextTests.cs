using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using InternProject.CsvFileConverter.Library.Extensions.Mapping;
using InternProject.CsvFileConverter.Library.Interfaces.Store.Interfaces.UpdateFormat.Interfaces;
using InternProject.CsvFileConverter.Library.Stores;
using InternProject.CsvFileConverter.Library.Stores.Extensions.UpdateFormat;
using InternProject.CsvFileConverter.XUnitTests.DataFixtures.Tests;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using Xunit;

namespace InternProject.CsvFileConverter.XUnitTests.Stores.Tests
{
    public class DealDataDbContextTests
    {
        [Fact]
        public void SecondTest()
        {
            var context = Substitute.For<DealDataDbContext>();
            var database = context.Set<DealData>();
        }

        [Fact]
        public void ShouldPass_WhenADealDataSetIsAdded_AndChangesAreSaved()
        {
            // Arrange
            var data = new FileWriterFixture().ValidInputDb;
            var db = new DbContextFixture();
            using (db)
            {
                db.Database.EnsureCreated();
                //var loaded = db.Set<DealDataFixture>()
                //    .AsNoTracking()
                //    .FirstOrDefault(d => d.V3DealId == data[0].V3DealId);

                //if (loaded == null)
                db.Set<DealDataFixture>().AddRange(data);
                //else
                //db.Set<DealDataFixture>().UpdateRange(data);

                // Act

                var result = db.Set<DealDataFixture>().Find("V3DealId");

                // Assert
                result.Should().NotBeNull();
            }
        }
    }
}