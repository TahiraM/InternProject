using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stage3_Verification;

namespace Stage3_Verification_Tests
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
            Assert.ThrowsException<FileNotFoundException>(action);

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
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Length, 1);
            Assert.AreEqual(result[0], expected);
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
            Assert.ThrowsException<FileLoadException>(action);

            File.Delete(fileName);
        }
    }
}