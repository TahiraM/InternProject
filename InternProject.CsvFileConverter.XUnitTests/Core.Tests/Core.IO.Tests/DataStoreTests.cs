using System.Collections.Generic;
using InternProject.CsvFileConverter.Library.Interfaces.Database.Interfaces;
using InternProject.CsvFileConverter.Library.Stores;
using InternProject.CsvFileConverter.XUnitTests.DataFixtures.Tests;
using NSubstitute;
using Xunit;

namespace InternProject.CsvFileConverter.XUnitTests.Core.Tests.Core.IO.Tests
{
    public class DataStoreTests
    {
        [Fact]
        public void Should_Pass_WhenMethodsAreCorrectAndCallsAreBeingSent()
        {
            // Arrange
            var dataStore = Substitute.For<IEnumerable<IDataStoreWriter>>();
            var fixture = new FileWriterFixture();

            var sut = new DataStore(dataStore);

            // Act
            sut.Store(fixture.ValidInput);

            // Assert 
            dataStore.Received(1).GetEnumerator();
        }
    }
}