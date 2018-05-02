using InternProject.CsvFileConverter.Library.Extensions.Mapping;
using InternProject.CsvFileConverter.Library.Stores;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using Xunit;

namespace InternProject.CsvFileConverter.XUnitTests.Stores.Tests
{
    public class DealDataDbContextTests
    {
        [Fact]
        public void ShouldPass_WhenADealDataSetIsAdded_AndChangesAreSaved()
        {
            // Arrange
            var mockDealSet = Substitute.For<DbSet<DealData>>();
            var mockDataContext = Substitute.For<DealDataDbContext>();

            // Act
            // mockDataContext.DealDatas.AddRange();

            // Assert
        }
    }
}