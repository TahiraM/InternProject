using System;
using System.IO;
using FluentAssertions;
using InternProject.CsvFileConverter.Library.Core.IO;
using Xunit;

namespace InternProject.CsvFileConverter.XUnitTests.Core.Tests.Core.IO.Tests
{
    public class FileReaderTests
    {
        [Fact]
        public void Should_ReadContent_Pass_WhenTheCsvFileIsPresentAndContainsTheRightData()
        {
            // Arrange
            const string fileName = "samplefile.csv";
            const string expected = "Test";
            File.WriteAllText(fileName, expected);

            var sut = new FileReader();

            // Act
            var result = sut.ReadContent(fileName);

            File.Delete(fileName);

            // Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void Should_ReadContent_ThrowTheRightError_WhenTheFileIsPresentButExtensionIsNotCsv()
        {
            // Arrange
            const string fileName = "samplefile";
            const string expected = "Test";
            File.WriteAllText(fileName, expected);

            var sut = new FileReader();

            // Act
            Action action = () => sut.ReadContent(fileName);

            // Assert
            action.Should().Throw<FileLoadException>();

            File.Delete(fileName);
        }

        [Fact]
        public void Should_TryFind_Fail_WhenThereIsNoCsvFilePresent()
        {
            // Arrange
            const string fileName = " ";
            var sut = new FileReader();

            // Act
            Action action = () => sut.ReadContent(fileName);

            // Assert
            action.Should().Throw<FileNotFoundException>();
        }
    }
}