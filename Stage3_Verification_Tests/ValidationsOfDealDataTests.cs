using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stage3_Verification;

namespace Stage3_Verification_Tests
{
    [TestClass]
    public class ValidationsOfDealDataTests
    {
        [TestMethod]
        public void ShouldPass_IfAnIntIsPassedThroughTheIntValidator()
        {
            // Arrange 
            const string num = "8";

            // Act
            var intergerTest = ValidationOfDealData.ThisInt(num);


            // Assert
            Assert.AreEqual(intergerTest, 8);
        }
        [TestMethod]
        public void Should_ThisInt_ThrowError_IfDataBeingParsedIsNotInCorrectFormat()
        {
            // Arrange
            var data = "Hellodkjs";

            // Act
            Action sut = () => ValidationOfDealData.ThisInt(data);

            // Assert
            Assert.ThrowsException<FormatException>(sut);
        }

        [TestMethod]
        public void ShouldPass_IfAnDoubleIsPassedThroughTheIntValidator()
        {
            // Arrange 
            const string num = "0.987";

            // Act
            var doubleTest = ValidationOfDealData.ThisDouble(num);

            // Assert
            Assert.AreEqual(doubleTest, 0.987);
        }

        [TestMethod]
        public void Should_ThisDouble_ThrowError_IfDataBeingParsedIsNotInCorrectFormat()
        {
            // Arrange
            var data = "hello";

            // Act
            Action sut = () => ValidationOfDealData.ThisDouble(data);

            // Assert
            Assert.ThrowsException<FormatException>(sut);
        }

        [TestMethod]
        public void ShouldPass_ThisDate_IfTheDataIsCorrect()
        {
            // Arrange 
            const string date = "12/4/2103";

            // Act
            var dateTest = ValidationOfDealData.ThisDate(date);

            // Assert
            Assert.AreEqual(dateTest, date);
        }

        [TestMethod]
        public void Should_ThisDate_ThrowError_IfDataBeingParsedIsNotInCorrectFormat()
        {
            // Arrange
            var data = "hello1234";

            // Act
            Action sut = () => ValidationOfDealData.ThisDate(data);

            // Assert
            Assert.ThrowsException<FormatException>(sut);
        }
    }
}