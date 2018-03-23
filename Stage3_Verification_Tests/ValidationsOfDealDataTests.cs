//using System;
//using System.Data;
//using CsvFileConverter;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace CsvFileConverterTests
//{
//    [TestClass]
//    public class ValidationsOfDealDataTests
//    {
//        [TestMethod]
//        public void ShouldPass_IfAnIntIsPassedThroughTheIntValidator()
//        {
//            // Arrange 
//            const string num = "8";

//            // Act
//            var intergerTest = FieldValidator.ThisInt(num);


//            // Assert
//            Assert.AreEqual(intergerTest, 8);
//        }
//        [TestMethod]
//        public void Should_ThisInt_ThrowError_IfDataBeingParsedIsNotInCorrectFormat()
//        {
//            // Arrange
//            var data = "Hellodkjs";

//            // Act
//            Action sut = () => FieldValidator.ThisInt(data);

//            // Assert
//            Assert.ThrowsException<FormatException>(sut);
//        }

//        [TestMethod]
//        public void ShouldPass_IfAnDoubleIsPassedThroughTheIntValidator()
//        {
//            // Arrange 
//            const string num = "0.987";

//            // Act
//            var doubleTest = FieldValidator.ThisDouble(num);

//            // Assert
//            Assert.AreEqual(doubleTest, 0.987);
//        }

//        [TestMethod]
//        public void Should_ThisDouble_ThrowError_IfDataBeingParsedIsNotInCorrectFormat()
//        {
//            // Arrange
//            var data = "hello";

//            // Act
//            Action sut = () => FieldValidator.ThisDouble(data);

//            // Assert
//            Assert.ThrowsException<FormatException>(sut);
//        }

//        [TestMethod]
//        public void ShouldPass_ThisDate_IfTheDataIsCorrect()
//        {
//            // Arrange 
//            const string date = "12/4/2103";

//            // Act
//            var dateTest = FieldValidator.ThisDate(date);

//            // Assert
//            Assert.AreEqual(dateTest, date);
//        }

//        [TestMethod]
//        public void Should_ThisDate_ThrowError_IfDataBeingParsedIsNotInCorrectFormat()
//        {
//            // Arrange
//            var data = "hello1234";

//            // Act
//            Action sut = () => FieldValidator.ThisDate(data);

//            // Assert
//            Assert.ThrowsException<IndexOutOfRangeException>(sut);
//        }
//    }
//}