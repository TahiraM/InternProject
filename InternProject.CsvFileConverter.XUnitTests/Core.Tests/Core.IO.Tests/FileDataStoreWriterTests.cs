using InternProject.CsvFileConverter.Library.Core.IO;
using InternProject.CsvFileConverter.Library.Extensions.Formatters;
using InternProject.CsvFileConverter.Library.Extensions.Mapping;
using InternProject.CsvFileConverter.Library.Interfaces.Core.IO.Interfaces;
using InternProject.CsvFileConverter.XUnitTests.DataFixtures.Tests;
using NSubstitute;
using Xunit;

namespace InternProject.CsvFileConverter.XUnitTests.Core.Tests.Core.IO.Tests
{
    public class FileDataStoreWriterTests
    {
        [Fact]
        public void Should_Pass_WhenMethodsAreCorrectAndCallsAreBeingSent()
        {
            // Arrange
            var fileWriter = Substitute.For<IFileWriter>();
            var output = Substitute.For<FileOutputOptions>();
            var fixture = new FileWriterFixture();

            var sut = new FileDataStoreWriter(fileWriter, output);

            // Act
            sut.Write(fixture.ValidInput);

            // Assert 
            fileWriter.Received(1).WriteContent(Arg.Any<string>(), Arg.Any<DealData[]>(), Arg.Any<FormatterType>());
        }
    }
}