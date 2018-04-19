using System;
using System.IO;
using CsvFileConverter;
using CsvFileConverter.MainProgramme;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace CsvFileConverterTests
{
    [TestClass]
    public class CsvToJsonConverterTests
    {
        [TestMethod]
        public void ShouldPass_IfTheInterFaceIsLinkedCOrrectlyAndAMOckInterfaceCanBeCreated()
        {
            // Arrange
            var fileReader = Substitute.For<IFileReader>();
            var dataExtractor = Substitute.For<IDataExtractor>();
            var fileWriter = Substitute.For<IFileWriter>();

            var sut = new CsvToJsonConverter(fileReader, dataExtractor, fileWriter);

            // Act
            sut.Convert("", "");

            // Assert
            fileReader.Received(1).ReadContent(Arg.Any<string>());
            fileWriter.Received(1).WriteContent(Arg.Any<string>(), Arg.Any<DealData[]>());
            dataExtractor.Received(1).ReadContent(Arg.Any<StringReader>(), Arg.Any<bool>());
        }

        [TestMethod]
        public void Should_Fail_WhenInputFileIsNull()
        {
            // Arrange
            string input = null;
            const string output = "test.json";
            var fileReader = Substitute.For<IFileReader>();
            var dataExtractor = Substitute.For<IDataExtractor>();
            var fileWriter = Substitute.For<IFileWriter>();

            var sut = new CsvToJsonConverter(fileReader, dataExtractor, fileWriter);

            // Act
            Action action = () => sut.Convert(input, output);

            // Assert 
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void Should_Fail_WhenOutputFileIsNull()
        {
            // Arrange
            string output = null;
            const string input = "test.csv";
            var fileReader = Substitute.For<IFileReader>();
            var dataExtractor = Substitute.For<IDataExtractor>();
            var fileWriter = Substitute.For<IFileWriter>();

            var sut = new CsvToJsonConverter(fileReader, dataExtractor, fileWriter);

            // Act
            Action action = () => sut.Convert(input, output);

            // Assert 
            action.Should().Throw<ArgumentNullException>();
        }
    }
}