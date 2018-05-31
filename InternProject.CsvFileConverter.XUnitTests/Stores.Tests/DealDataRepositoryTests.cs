using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternProject.CsvFileConverter.Library.Extensions.Formatters;
using InternProject.CsvFileConverter.Library.Extensions.Mapping;
using InternProject.CsvFileConverter.Library.Interfaces.Database.Interfaces;
using InternProject.CsvFileConverter.Library.Stores;
using InternProject.CsvFileConverter.XUnitTests.DataFixtures.Tests;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using Xunit;

namespace InternProject.CsvFileConverter.XUnitTests.Stores.Tests
{
    public class DealDataRepositoryTests
    {
        //[Fact]
        //public void Should_Pass_WhenMethodsAreCorrectAndCallsAreBeingSent()
        //{
        //    // Arrange
        //    var fixture = new FileWriterFixture();
        //    var context = Substitute.For<IDbContextFactory>();
        //    var dataStoreWriter = Substitute.For<IDealDataRepository>();

        //    var sut = new DealDataRepository(context);

        //    // Act
        //    sut.SaveMany(fixture.ValidInput);

        //    // Assert 
        //    dataStoreWriter.Received(1).SaveMany(Arg.Any<DealData[]>());
        //    sut.Received(1).SaveMany(Arg.Any<DealData[]>());
        //}
    }
    
        
}
