using System;
using System.Data;
using CsvFileConverter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsvFileConverterTests
{
    [TestClass]
    public class LegacyDataExtractorTest
    {
        [TestMethod]
        public void Should_ExtractSectorId_Pass_WhenTheDataIsValidAndAvailable()
        {
            // Arrange
            var fixture = new LegacyDataExtractorFixture();
            var expected = fixture.ValidOutput;
            var sut = new LegacyDataExtractor();

            // Act
            var actual = sut.ExtractWithoutHeader(fixture.ValidInput);

            // Assert
            Assert.AreEqual(expected.Length, actual.Length);
            Assert.AreEqual(expected[0].SectorId, actual[0].SectorId);
        }

        [TestMethod]
        public void Should_ExtractSectorId_ReturnsNullForSectorId_WhenSectorIdIsNotInTheRightFormat()
        {
            // Arrange
            var fixture = new LegacyDataExtractorFixture();
            var sut = new LegacyDataExtractor();

            // Act
            Action action = () => sut.Extract(fixture.InvalidInputSectorId, false);

            // Assert
            Assert.ThrowsException<FormatException>(action);
        }

        [TestMethod]
        public void Should_ExtractCountryId_Pass_WhenTheDataIsValidAndAvailable()
        {
            // Arrange
            var fixture = new LegacyDataExtractorFixture();
            var expected = fixture.ValidOutput;
            var sut = new LegacyDataExtractor();

            // Act
            var actual = sut.ExtractWithoutHeader(fixture.ValidInput);

            // Assert
            Assert.AreEqual(expected.Length, actual.Length);
            Assert.AreEqual(expected[0].CountryId, actual[0].CountryId);
        }

        [TestMethod]
        public void Should_ExtractCountryId_ReturnsNullForSectorId_WhenCountryIdIsNotInTheRightFormat()
        {
            // Arrange
            var fixture = new LegacyDataExtractorFixture();
            var sut = new LegacyDataExtractor();

            // Act
            Action action = () => sut.Extract(fixture.InvalidInputCountryId, false);

            // Assert
            Assert.ThrowsException<FormatException>(action);
        }

        [TestMethod]
        public void Should_ExtractTransTypeId_Pass_WhenTheDataIsValidAndAvailable()
        {
            // Arrange
            var fixture = new LegacyDataExtractorFixture();
            var expected = fixture.ValidOutput;
            var sut = new LegacyDataExtractor();

            // Act
            var actual = sut.ExtractWithoutHeader(fixture.ValidInput);

            // Assert
            Assert.AreEqual(expected.Length, actual.Length);
            Assert.AreEqual(expected[0].TransactionTypeId, actual[0].TransactionTypeId);
        }

        [TestMethod]
        public void Should_ExtractTransTypeId_ReturnsNullForSectorId_WhenTransTypeIdIsNotInTheRightFormat()
        {
            // Arrange
            var fixture = new LegacyDataExtractorFixture();
            var sut = new LegacyDataExtractor();

            // Act
            Action action = () => sut.Extract(fixture.InvalidInputTransTypeId, false);

            // Assert
            Assert.ThrowsException<FormatException>(action);
        }

        [TestMethod]
        public void Should_ExtractTransFees_Pass_WhenTheDataIsValidAndAvailable()
        {
            // Arrange
            var fixture = new LegacyDataExtractorFixture();
            var expected = fixture.ValidOutput;
            var sut = new LegacyDataExtractor();

            // Act
            var actual = sut.ExtractWithoutHeader(fixture.ValidInput);

            // Assert
            Assert.AreEqual(expected.Length, actual.Length);
            Assert.AreEqual(expected[0].TransactionFees, actual[0].TransactionFees);
        }

        [TestMethod]
        public void Should_ExtractTransFees_ReturnsNullForSectorId_WhenTransFeesIsNotInTheRightFormat()
        {
            // Arrange
            var fixture = new LegacyDataExtractorFixture();
            var sut = new LegacyDataExtractor();

            // Act
            Action action = () => sut.Extract(fixture.InvalidInputTransFees, false);

            // Assert
            Assert.ThrowsException<FormatException>(action);
        }

        [TestMethod]
        public void Should_ExtractOtherFees_Pass_WhenTheDataIsValidAndAvailable()
        {
            // Arrange
            var fixture = new LegacyDataExtractorFixture();
            var expected = fixture.ValidOutput;
            var sut = new LegacyDataExtractor();

            // Act
            var actual = sut.ExtractWithoutHeader(fixture.ValidInput);

            // Assert
            Assert.AreEqual(expected.Length, actual.Length);
            Assert.AreEqual(expected[0].OtherFees, actual[0].OtherFees);
        }

        [TestMethod]
        public void Should_ExtractOtherFees_ReturnsNullForSectorId_WhenOtherFeesIsNotInTheRightFormat()
        {
            // Arrange
            var fixture = new LegacyDataExtractorFixture();
            var sut = new LegacyDataExtractor();

            // Act
            Action action = () => sut.Extract(fixture.InvalidInputOtherFees, false);

            // Assert
            Assert.ThrowsException<FormatException>(action);
        }

        [TestMethod]
        public void Should_ExtractExitDate_Pass_WhenTheDataIsValidAndAvailable()
        {
            // Arrange
            var fixture = new LegacyDataExtractorFixture();
            var expected = fixture.ValidOutput;
            var sut = new LegacyDataExtractor();

            // Act
            var actual = sut.ExtractWithoutHeader(fixture.ValidInput);

            // Assert
            Assert.AreEqual(expected.Length, actual.Length);
            Assert.AreEqual(expected[0].ExitDate, actual[0].ExitDate);
        }

        [TestMethod]
        public void Should_ExtractExitDate_ReturnsNullForSectorId_WhenExitDateIsNotInTheRightFormat()
        {
            // Arrange
            var fixture = new LegacyDataExtractorFixture();
            var sut = new LegacyDataExtractor();

            // Act
            Action action = () => sut.Extract(fixture.InvalidInputExitDate, false);

            // Assert
            Assert.ThrowsException<DataException>(action);
        }
    }
}