//using System;
//using System.IO;
//using CsvFileConverter;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NSubstitute;
//using NSubstitute.ExceptionExtensions;

//namespace CsvFileConverterTests
//{
//    [TestClass]
//    public class DataExtractorTest
//    {
//        [TestMethod]
//        public void Should_Extract_Pass_WhenTheDataIsValidAndAvailable()
//        {
//            // Arrange
//            var file = File.ReadAllLines("Deal.csv").ToString();
//            var data = new[] {file};
//            var extractData = new LegacyDataExtractor();
//            var expected = extractData.Extract(data);

//            var legacyDataExtractor = Substitute.For<ILegacyDataExtractor>();
//            legacyDataExtractor.Extract(Arg.Any<string[]>()).Returns(expected);

//            var sut = new DataExtractor(legacyDataExtractor);

//            // Act
//            var actual = sut.Extract(data);

//            // Assert
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void Should_Extract_ThrowError_IfDataBeingParsedIsNotInCorrectFormat()
//        {
//            // Arrange
//            var data = new[] {"help", "hi", "test"};

//            var legacyDataExtractor = Substitute.For<ILegacyDataExtractor>();
//            var sut = new DataExtractor(legacyDataExtractor);
//            legacyDataExtractor.Extract(Arg.Any<string[]>()).Throws(new FormatException("Data Is Not Valid"));

//            // Act
//            Action action = () => sut.Extract(data);

//            // Assert
//            Assert.ThrowsException<FormatException>(action);
//        }

//        [TestMethod]
//        public void Should_Extract_ThrowError_IfDataStringBeingParsedIsEmpty()
//        {
//            // Arrange
//            var data = new[] { string.Empty };

//            var legacyDataExtractor = Substitute.For<ILegacyDataExtractor>();
//            var sut = new DataExtractor(legacyDataExtractor);
//            legacyDataExtractor.Extract(Arg.Any<string[]>()).Throws(new FormatException("Data Is Not Valid"));

//            // Act
//            Action action = () => sut.Extract(data);

//            // Assert
//            Assert.ThrowsException<FormatException>(action);
//        }
//    }
//}