using InternProject.CsvFileConverter.Library.Extensions.Mapping;
using InternProject.CsvFileConverter.Library.Interfaces.Database.Interfaces;
using InternProject.CsvFileConverter.Library.Stores;
using InternProject.CsvFileConverter.XUnitTests.DataFixtures.Tests;
using NSubstitute;
using Xunit;

namespace InternProject.CsvFileConverter.XUnitTests.Stores.Tests
{
    public class EfDataStoreWriterTests
    {
        [Fact]
        public void Should_Pass_WhenMethodsAreCorrectAndCallsAreBeingSent()
        {
            // Arrange
            var dataStoreWriter = Substitute.For<IDealDataRepository>();
            var fixture = new FileWriterFixture();

            var sut = new EfDataStoreWriter(dataStoreWriter);

            // Act
            sut.Write(fixture.ValidInput);

            // Assert 
            dataStoreWriter.Received(1).SaveMany(Arg.Any<DealData[]>());
        }
    }
}