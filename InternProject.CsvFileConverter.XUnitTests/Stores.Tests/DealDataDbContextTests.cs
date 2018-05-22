using System.Linq;
using FluentAssertions;
using FluentAssertions.Common;
using InternProject.CsvFileConverter.Library.Extensions.Mapping;
using InternProject.CsvFileConverter.Library.Stores;
using InternProject.CsvFileConverter.XUnitTests.DataFixtures.Tests;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace InternProject.CsvFileConverter.XUnitTests.Stores.Tests
{
    public class DealDataDbContextTests
    {
        [Fact]
        public void Should_Pass_WhenCorrectDataIsSavedToDatabase()
        {
            // Arrange
            int? result = 0;
            var fixture = new FileWriterFixture().ValidInput;
            var options = new DbContextOptionsBuilder<DealDataDbContext>()
                .UseInMemoryDatabase("DealData")
                .Options;

            // Act
            using (var db = new DealDataDbContext(options))
            {
                foreach (var data in fixture)
                {
                    var loaded = db.Set<DealData>()
                        .AsNoTracking()
                        .FirstOrDefault(d => d.V3DealId == data.V3DealId);

                    if (loaded == null)
                        db.Set<DealData>().Add(data);
                    else
                        db.Set<DealData>().Update(data);

                    result = db.Set<DealData>().Find(data.V3DealId).CountryId;
                }
            }

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveValue();
            result.Should().IsSameOrEqualTo(129);
        }
    }
}