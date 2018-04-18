//using System;
//using System.Collections.Generic;
//using System.IO;
//using Castle.Core.Logging;
//using CsvFileConverter;
//using CsvHelper.TypeConversion;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NSubstitute;
//using NSubstitute.ExceptionExtensions;
//using Serilog;

//namespace CsvFileConverterTests
//{
//    [TestClass]
//    public class DataExtractorTest
//    {
//        public void Should_Extract_Pass_WhenTheDataIsValidAndAvailable()
//        {
//            // Arrange
//            var fixture = new LegacyDataExtractorFixture();
//            var expected = fixture.ValidOutput;
//            StringReader input = new StringReader(fixture.ValidInput);
//            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);

//            // Act
//            var actual = sut.ReadContent(input, false);

//            // Assert
//            Assert.AreEqual(expected.Length, actual.Length);
//            Assert.AreEqual(expected[0].SectorId, actual[0].SectorId);
//        }



//        [TestMethod]
//        public void Should_ExtractSectorId_ReturnsNullForSectorId_WhenSectorIdIsNotInTheRightFormat()
//        {
//            // Arrange
//            var fixture = new LegacyDataExtractorFixture();
//            StringReader input = new StringReader(fixture.InvalidInputSectorId);
//            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);

//            // Act
//            Action action = () => sut.ReadContent(input, false);

//            // Assert
//            Assert.ThrowsException<FormatException>(action);
//        }

//        [TestMethod]
//        public void Should_ExtractCountryId_Pass_WhenTheDataIsValidAndAvailable()
//        {
//            // Arrange
//            var fixture = new LegacyDataExtractorFixture();
//            var expected = fixture.ValidOutput;
//            StringReader input = new StringReader(fixture.ValidInput);
//            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);

//            // Act
//            var actual = sut.ReadContent(input, false);

//            // Assert
//            Assert.AreEqual(expected.Length, actual.Length);
//            Assert.AreEqual(expected[0].CountryId, actual[0].CountryId);
//        }

//        [TestMethod]
//        public void Should_ExtractCountryId_ReturnsNullForSectorId_WhenCountryIdIsNotInTheRightFormat()
//        {
//            // Arrange
//            var fixture = new LegacyDataExtractorFixture();
//            StringReader input = new StringReader(fixture.InvalidInputCountryId);
//            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);

//            // Act
//            Action action = () => sut.ReadContent(input, false);

//            // Assert
//            Assert.ThrowsException<FormatException>(action);
//        }

//        [TestMethod]
//        public void Should_ExtractTransTypeId_Pass_WhenTheDataIsValidAndAvailable()
//        {
//            // Arrange
//            var fixture = new LegacyDataExtractorFixture();
//            var expected = fixture.ValidOutput;
//            StringReader input = new StringReader(fixture.ValidInput);
//            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);

//            // Act
//            var actual = sut.ReadContent(input, false);

//            // Assert
//            Assert.AreEqual(expected.Length, actual.Length);
//            Assert.AreEqual(expected[0].TransactionTypeId, actual[0].TransactionTypeId);
//        }

//        [TestMethod]
//        public void Should_ExtractTransTypeId_ReturnsNullForTransTypeId_WhenTransTypeIdIsNotInTheRightFormat()
//        {
//            // Arrange
//            var fixture = new LegacyDataExtractorFixture();
//            StringReader input = new StringReader(fixture.InvalidInputTransTypeId);
//            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);

//            // Act
//            Action action = () => sut.ReadContent(input, false);

//            // Assert
//            Assert.ThrowsException<FormatException>(action);
//        }

//        [TestMethod]
//        public void Should_ExtractTransFees_Pass_WhenTheDataIsValidAndAvailable()
//        {
//            // Arrange
//            var fixture = new LegacyDataExtractorFixture();
//            var expected = fixture.ValidOutput;
//            StringReader input = new StringReader(fixture.ValidInput);
//            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);

//            // Act
//            var actual = sut.ReadContent(input, false);

//            // Assert
//            Assert.AreEqual(expected.Length, actual.Length);
//            Assert.AreEqual(expected[0].TransactionFees, actual[0].TransactionFees);
//        }

//        [TestMethod]
//        public void Should_ExtractTransFees_ReturnsNullFor_WhenTransFeesIsNotInTheRightFormat()
//        {
//            // Arrange
//            var fixture = new LegacyDataExtractorFixture();
//            StringReader input = new StringReader(fixture.InvalidInputTransFees);
//            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);

//            // Act
//            Action action = () => sut.ReadContent(input, false);

//            // Assert
//            Assert.ThrowsException<FormatException>(action);
//        }

//        [TestMethod]
//        public void Should_ExtractOtherFees_Pass_WhenTheDataIsValidAndAvailable()
//        {
//            // Arrange
//            var fixture = new LegacyDataExtractorFixture();
//            var expected = fixture.ValidOutput;
//            StringReader input = new StringReader(fixture.ValidInput);
//            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);

//            // Act
//            var actual = sut.ReadContent(input, false);

//            // Assert
//            Assert.AreEqual(expected.Length, actual.Length);
//            Assert.AreEqual(expected[0].OtherFees, actual[0].OtherFees);
//        }

//        [TestMethod]
//        public void Should_ExtractOtherFees_ReturnsNullFor_WhenOtherFeesIsNotInTheRightFormat()
//        {
//            // Arrange
//            var fixture = new LegacyDataExtractorFixture();
//            StringReader input = new StringReader(fixture.InvalidInputOtherFees);
//            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);

//            // Act
//            Action action = () => sut.ReadContent(input, false);

//            // Assert
//            Assert.ThrowsException<FormatException>(action);
//        }

//        [TestMethod]
//        public void Should_ExtractExitDate_Pass_WhenTheDataIsValidAndAvailable()
//        {
//            // Arrange
//            var fixture = new LegacyDataExtractorFixture();
//            var expected = fixture.ValidInput;
//            StringReader input = new StringReader(fixture.ValidInput);
//            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);

//            // Act
//            var actual = sut.ReadContent(input, false);

//            // Assert
//            Assert.AreEqual(expected.Length, actual.Length);
//           // Assert.AreEqual(expected[0].ExitDate, actual[0].ExitDate);
//        }

//        [TestMethod]
//        public void Should_ExtractExitDate_ReturnsNullForExitDate_WhenExitDateIsNotInTheRightFormat()
//        {
//            // Arrange
//            var fixture = new LegacyDataExtractorFixture();
//            StringReader input = new StringReader(fixture.InvalidInputExitDate);
//            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);

//            // Act
//            Action action = () => sut.ReadContent(input, false);

//            // Assert
//            Assert.ThrowsException<FormatException>(action);
//        }


//        //[TestMethod]
//        //public void Should_Extract_ThrowError_IfDataBeingParsedIsNotInCorrectFormat()
//        //{
//        //    // Arrange
//        //    var data = new[] { "help", "hi", "test" };

//        //    var legacyDataExtractor = Substitute.For<ILegacyDataExtractor>();
//        //    var sut = new DataExtractor(legacyDataExtractor);
//        //    legacyDataExtractor.Extract(Arg.Any<string[]>()).Throws(new FormatException("Data Is Not Valid"));

//        //    // Act
//        //    Action action = () => sut.Extract(data);

//        //    // Assert
//        //    Assert.ThrowsException<FormatException>(action);
//        //}

//        //[TestMethod]
//        //public void Should_Extract_ThrowError_IfDataStringBeingParsedIsEmpty()
//        //{
//        //    // Arrange
//        //    var data = new[] { string.Empty };

//        //    var legacyDataExtractor = Substitute.For<ILegacyDataExtractor>();
//        //    var sut = new DataExtractor(legacyDataExtractor);
//        //    legacyDataExtractor.Extract(Arg.Any<string[]>()).Throws(new FormatException("Data Is Not Valid"));

//        //    // Act
//        //    Action action = () => sut.Extract(data);

//        //    // Assert
//        //    Assert.ThrowsException<FormatException>(action);
//        //}

//    }
//}