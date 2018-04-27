using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using InternProject.CsvFileConverter.Library;
using NSubstitute;
using Xunit;

namespace InternProject.CsvFileConverter.XUnitTests
{
    public class CsvToJsonConverterTests
    {
        //[Fact]
        //public void ShouldPass_IfTheInterFaceIsLinkedCorrectlyAndAMockInterfaceCanBeCreated()
        //{
        //    // Arrange
        //    var fileReader = Substitute.For<IFileReader>();
        //    var dataExtractor = Substitute.For<IDataExtractor>();
        //    var fileWriter = Substitute.For<IFileWriter>();

        //    var sut = new CsvToJsonConverter(fileReader, dataExtractor, fileWriter);

        //    // Act
        //    sut.Convert("", "");

        //    // Assert
        //    fileReader.Received(1).ReadContent(Arg.Any<string>());
        //    fileWriter.Received(1).WriteContent(Arg.Any<string>(), Arg.Any<DealData[]>());
        //    dataExtractor.Received(1).ReadContent(Arg.Any<StringReader>(), Arg.Any<bool>());
        //}

      

        //[Theory]
        //[InlineData(null, "test.json")]
        //[InlineData("test.csv",null)]
        //public void Should_Fail_WhenInputOrOutputFilesAreNull(string input, string output)
        //{
        //    // Arrange
        //    var fileReader = Substitute.For<IFileReader>();
        //    var dataExtractor = Substitute.For<IDataExtractor>();
        //    var fileWriter = Substitute.For<IFileWriter>();

        //    var sut = new CsvToJsonConverter(fileReader, dataExtractor, fileWriter);

        //    // Act
        //    Action action = () => sut.Convert(input, output);

        //    // Assert 
        //    action.Should().Throw<ArgumentNullException>();
        //}
    }

    
}