using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stage3_Verification;

namespace Stage3_Verification_Tests
{
    [TestClass]
    public class FileWriterTests
    {
        [TestMethod]
        public void Should_ReadContent_Pass_WhenTheJsonFileIsPresentAndContainsTheRightData()
        {
            // Arrange
            const string fileName = "samplefile.json";
            const string expected = "Test";
            var sut = new FileWriter();

            // Act
            sut.WriteContent(fileName, expected, true);
            var result = File.ReadAllLines(fileName);


            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Length, 1);
            Assert.AreEqual(result[0], expected);
        }


        [TestMethod]
        public void ShouldPass_IfFileIsNotAvailable_OverrideIfFileIfFileIsAvailable()
        {
            // Arrange
            const string fileName = "Vali.json";
            const string expected = "Hello";
            var sut = new FileWriter();

            // Act
            sut.WriteContent(fileName, expected, true);
            var result = File.ReadAllLines(fileName);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Length, 1);
            Assert.AreEqual(result[0], expected);
            File.Delete(fileName);
        }

        [TestMethod]
        public void ShouldPass_FileBeingSavedIsBeingSavedInCorrectLocation()
        {
            // Arrange
            const string fileName = "Vali.json";
            const string expected = "Hello";
            const string expecPath =
                "C:\\GIT\\InternProject\\Stage3_Verification_Tests\\bin\\Debug\\netcoreapp2.0\\Vali.json";
            var sut = new FileWriter();

            // Act
            sut.WriteContent(fileName, expected);
            var filePath = Path.GetFullPath(fileName);

            // Assert
            Assert.AreEqual(filePath, expecPath);
        }

        [TestMethod]
        public void ShouldFail_WriteComment_IfFileCannotBeOverwritten()
        {
            // Arrange
            const string fileName = "Vali.json";
            const string expected = "Hello";
            var sut = new FileWriter();

            // Act
            Action action = () => sut.WriteContent(fileName, expected, false);

            // Assert
            Assert.ThrowsException<ApplicationException>(action);
        }
    }
}