using System;
using System.IO;
using FluentAssertions;
using InternProject.CsvFileConverter.Library.Core;
using InternProject.CsvFileConverter.Library.Extensions.Mapping;
using InternProject.CsvFileConverter.Library.Interfaces.Core.Conversions.Interfaces;
using InternProject.CsvFileConverter.Library.Interfaces.Core.IO.Interfaces;
using InternProject.CsvFileConverter.Library.Interfaces.Database.Interfaces;
using NSubstitute;
using Xunit;

namespace InternProject.CsvFileConverter.XUnitTests.Core.Tests.Core.Converstions.Tests
{
    public class CsvToJsonConverterTests
    {
        [Fact]
        public void Should_Fail_WhenInputOrOutputFilesAreNull()
        {
            // Arrange
            var fileReader = Substitute.For<IFileReader>();
            var dataExtractor = Substitute.For<IDataExtractor>();
            var dataStore = Substitute.For<IDataStore>();

            var sut = new CsvToJsonConverter(fileReader, dataExtractor, dataStore);

            // Act
            Action action = () => sut.Convert(null);

            // Assert 
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ShouldPass_IfTheInterFaceIsLinkedCorrectlyAndAMockInterfaceCanBeCreated()
        {
            // Arrange
            var fileReader = Substitute.For<IFileReader>();
            var dataExtractor = Substitute.For<IDataExtractor>();
            var dataStore = Substitute.For<IDataStore>();

            var sut = new CsvToJsonConverter(fileReader, dataExtractor, dataStore);

            // Act
            sut.Convert("");

            // Assert
            fileReader.Received(1).ReadContent(Arg.Any<string>());
            dataStore.Received(1).Store(Arg.Any<DealData[]>());
            dataExtractor.Received(1).ReadContent(Arg.Any<StringReader>(), Arg.Any<bool>());
        }
    }
}