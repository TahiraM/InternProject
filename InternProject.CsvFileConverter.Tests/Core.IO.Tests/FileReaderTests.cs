using System;
using System.IO;
using FluentAssertions;
using InternProject.CsvFileConverter.Library.Core.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsvFileConverterTests.Core.IO.Tests
{
    [TestClass]
    public class FileReaderTests
    {
        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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
    }
}