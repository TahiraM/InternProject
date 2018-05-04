using InternProject.CsvFileConverter.Library.Extensions.Mapping;
using InternProject.CsvFileConverter.Library.Interfaces.Store.Interfaces.UpdateFormat.Interfaces;
using InternProject.CsvFileConverter.Library.Stores;
using InternProject.CsvFileConverter.XUnitTests.DataFixtures.Tests;
using NSubstitute;
using Xunit;

namespace InternProject.CsvFileConverter.XUnitTests.Stores.Tests
{
    public class DealDataRepositoryTests
    {
        [Fact]
        public void Should_Pass_WhenMethodsAreCorrectAndCallsAreBeingSent()
        {
            // Arrange
            var dataStoreWriter = Substitute.For<IUpdateRecords>();
            var fixture = new FileWriterFixture();

            var sut = new DealDataRepository(dataStoreWriter);

            // Act
            sut.SaveMany(fixture.ValidInput);

            // Assert 
            dataStoreWriter.Received(1).UpdateRecords(Arg.Any<DealData[]>());
        }
    }
}