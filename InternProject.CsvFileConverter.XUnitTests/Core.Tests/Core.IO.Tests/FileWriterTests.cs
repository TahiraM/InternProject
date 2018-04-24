﻿using System.IO;
using FluentAssertions;
using FluentAssertions.Common;
using InternProject.CsvFileConverter.Library;
using Xunit;

namespace InternProject.CsvFileConverter.XUnitTests
{
    public class FileWriterTests
    {
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
        public void ShouldPass_WriteContent_DataShouldBeConvertedToCorrectFileTypeWithOverwrite(string fileName, bool overwrite)
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
        [InlineData("testing.xml", true, FormatterType.Xml)]
        [InlineData("testing.json", true, FormatterType.Json)]
        public void ShouldPass_WriteContent_DataShouldBeConvertedToCorrectFileTypeWithFormatter(string fileName, bool overwrite, FormatterType type)
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
    }
}