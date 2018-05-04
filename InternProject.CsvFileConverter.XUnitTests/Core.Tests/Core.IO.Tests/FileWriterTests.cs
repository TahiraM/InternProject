using System;
using System.IO;
using FluentAssertions;
using FluentAssertions.Common;
using InternProject.CsvFileConverter.Library.Core.IO;
using InternProject.CsvFileConverter.Library.Extensions.Formatters;
using InternProject.CsvFileConverter.XUnitTests.DataFixtures.Tests;
using Xunit;

namespace InternProject.CsvFileConverter.XUnitTests.Core.Tests.Core.IO.Tests
{
    public class FileWriterTests
    {
        [Theory]
        [InlineData("testing.xml")]
        [InlineData("testing.json")]
        public void ShouldPass_WriteContent_DataShouldBeConvertedToCorrectFileType(string fileName)
        {
            // Arrange
            var fixture = new FileWriterFixture();
            var expected = fixture.InValidInput;
            var sut = new FileWriter(fixture.GetFormatters());

            // Act
            sut.WriteContent(fileName, expected);
            var result = File.ReadAllLines(fileName);

            // Assert
            result.Should().NotBeNullOrEmpty();
            File.Exists(fileName).Should().BeTrue();
        }

        [Theory]
        [InlineData("testing.xml", true)]
        [InlineData("testing.json", true)]
        public void ShouldPass_WriteContent_DataShouldBeConvertedToCorrectFileTypeWithOverwrite(string fileName,
            bool overwrite)
        {
            // Arrange
            var fixture = new FileWriterFixture();
            var expected = fixture.InValidInput;
            var sut = new FileWriter(fixture.GetFormatters());

            // Act
            sut.WriteContent(fileName, expected, overwrite);
            var result = File.ReadAllLines(fileName);

            // Assert
            result.Should().NotBeNullOrEmpty();
            File.Exists(fileName).Should().BeTrue();
        }

        [Theory]
        [InlineData("testing.xml", FormatterType.Xml)]
        [InlineData("testing.json", FormatterType.Json)]
        public void ShouldPass_WriteContent_DataShouldBeConvertedToCorrectFileTypeWithoutOverwrite(string fileName,
            FormatterType type)
        {
            // Arrange
            var fixture = new FileWriterFixture();
            var expected = fixture.InValidInput;
            var sut = new FileWriter(fixture.GetFormatters());

            // Act
            sut.WriteContent(fileName, expected, type);
            var result = File.ReadAllLines(fileName);

            // Assert
            result.Should().NotBeNullOrEmpty();
            File.Exists(fileName).Should().BeTrue();
        }

        [Theory]
        [InlineData("testing.xml", true, FormatterType.Xml)]
        [InlineData("testing.json", true, FormatterType.Json)]
        public void ShouldPass_WriteContent_DataShouldBeConvertedToCorrectFileTypeWithFormatter(string fileName,
            bool overwrite, FormatterType type)
        {
            // Arrange
            var fixture = new FileWriterFixture();
            var expected = fixture.InValidInput;
            var sut = new FileWriter(fixture.GetFormatters());

            // Act
            sut.WriteContent(fileName, expected, overwrite, type);
            var result = File.ReadAllLines(fileName);

            // Assert
            result.Should().NotBeNullOrEmpty();
            File.Exists(fileName).Should().BeTrue();
        }

        

        [Theory]
        [InlineData("testing.json", null, FormatterType.Json)]
        [InlineData(null, true, FormatterType.Json)]
        public void ShouldFail_ThrowError_WriteContent_IfDataNotInCorrectFormat(string fileName,
            bool overwrite, FormatterType type)
        {
            // Arrange
            var fixture = new FileWriterFixture();
            var expected = fixture.InValidInput;
            var sut = new FileWriter(fixture.GetFormatters());

            // Act
            Action action = ()=> sut.WriteContent(fileName, expected, overwrite, type);
            

            // Assert
            action.Should().Throw<Exception>();
        }

        [Fact]
        public void Should_WriteContent_Pass_WhenTheJsonFileIsPresentAndContainsTheRightData()
        {
            // Arrange
            var fileName = "testing.json";
            var fixture = new FileWriterFixture();
            var actual = fixture.ValidOutput;
            var expected = fixture.ValidInput;
            var sut = new FileWriter(fixture.GetFormatters());

            // Act
            sut.WriteContent(fileName, expected);
            var result = File.ReadAllLines(fileName);


            // Assert
            result.Should().NotBeNullOrEmpty();
            result[0].Should().IsSameOrEqualTo(actual);
            File.Exists(fileName).Should().BeTrue();
            result[0].Should().StartWith("[{").And.EndWith("}]");
        }

        [Fact]
        public void ShouldPass_FileBeingSavedIsBeingSavedInCorrectLocation()
        {
            // Arrange
            var fixture = new FileWriterFixture();
            const string fileName = "Vali.json";
            var expected = fixture.ValidInput;
            const string expecPath =
                "Vali.json";
            var sut = new FileWriter(fixture.GetFormatters());

            // Act
            sut.WriteContent(fileName, expected);
            var filePath = Path.GetFullPath(fileName);

            // Assert
            expecPath.Should().IsSameOrEqualTo(filePath);
        }
    }
}