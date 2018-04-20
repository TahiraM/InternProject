using System;
using System.IO;
using CsvFileConverter;
using CsvHelper;
using CsvHelper.TypeConversion;
using FluentAssertions;
using FluentAssertions.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Serilog;
using MissingFieldException = CsvHelper.MissingFieldException;

namespace CsvFileConverterTests
{
    [TestClass]
    public class DataExtractorTest
    {
        public void Should_ExtractSectorId_Pass_WhenTheDataIsValidAndAvailable()
        {
            // Arrange
            var fixture = new DataExtractorFixture();
            var expected = fixture.ValidOutput;
            var input = new StringReader(fixture.ValidInput);
            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);

            // Act
            var actual = sut.ReadContent(input, false);

            // Assert
            expected.Should().Contain(item => item.SectorId == 1);
            expected.Length.Should().IsSameOrEqualTo(actual.Length);
            expected[0].Should().IsSameOrEqualTo(actual[0]);
        }


        [TestMethod]
        public void Should_ExtractSectorId_ReturnsNullForSectorId_WhenSectorIdIsNotInTheRightFormat()
        {
            // Arrange
            var fixture = new DataExtractorFixture();
            var input = new StringReader(fixture.InvalidInputSectorId);
            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);

            // Act
            Action action = () => sut.ReadContent(input, false);

            // Assert
            action.Should().Throw<TypeConverterException>();
        }

        [TestMethod]
        public void Should_ExtractSectorId_ReturnError_WhenSectorIdIsEmpty()
        {
            // Arrange
            var fixture = new DataExtractorFixture();
            var input = new StringReader(fixture.EmptyInputSectorId);
            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);

            // Act
            Action action = () => sut.ReadContent(input, false);

            // Assert
            action.Should().Throw<TypeConverterException>();
        }

        [TestMethod]
        public void Should_ExtractCountryId_Pass_WhenTheDataIsValidAndAvailable()
        {
            // Arrange
            var fixture = new DataExtractorFixture();
            var expected = fixture.ValidOutput;
            var input = new StringReader(fixture.ValidInput);
            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);

            // Act
            var actual = sut.ReadContent(input, false);

            // Assert
            expected.Should().Contain(item => item.CountryId == 229);
            expected.Length.Should().IsSameOrEqualTo(actual.Length);
            expected[0].Should().IsSameOrEqualTo(actual[0]);
        }

        [TestMethod]
        public void Should_ExtractCountryId_ReturnsNullForSectorId_WhenCountryIdIsNotInTheRightFormat()
        {
            // Arrange
            var fixture = new DataExtractorFixture();
            var input = new StringReader(fixture.InvalidInputCountryId);
            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);

            // Act
            Action action = () => sut.ReadContent(input, false);

            // Assert
            action.Should().Throw<TypeConverterException>();
        }

        [TestMethod]
        public void Should_ExtractCountryId_ReturnError_WhenCountryIdIsEmpty()
        {
            // Arrange
            var fixture = new DataExtractorFixture();
            var input = new StringReader(fixture.EmptyInputCountryId);
            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);

            // Act
            Action action = () => sut.ReadContent(input, false);

            // Assert
            action.Should().Throw<TypeConverterException>();
        }

        [TestMethod]
        public void Should_ExtractTransTypeId_Pass_WhenTheDataIsValidAndAvailable()
        {
            // Arrange
            var fixture = new DataExtractorFixture();
            var expected = fixture.ValidOutput;
            var input = new StringReader(fixture.ValidInput);
            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);

            // Act
            var actual = sut.ReadContent(input, false);

            // Assert
            expected.Should().Contain(item => item.TransactionTypeId == 209);
            expected.Length.Should().IsSameOrEqualTo(actual.Length);
            expected[0].Should().IsSameOrEqualTo(actual[0]);
        }

        [TestMethod]
        public void Should_ExtractTransTypeId_ReturnsNullForTransTypeId_WhenTransTypeIdIsNotInTheRightFormat()
        {
            // Arrange
            var fixture = new DataExtractorFixture();
            var input = new StringReader(fixture.InvalidInputTransTypeId);
            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);

            // Act
            Action action = () => sut.ReadContent(input, false);

            // Assert
            action.Should().Throw<TypeConverterException>();
        }

        [TestMethod]
        public void Should_ExtractTransTypeId_ReturnError_WhenTransTypeIdIsEmpty()
        {
            // Arrange
            var fixture = new DataExtractorFixture();
            var input = new StringReader(fixture.EmptyInputCountryId);
            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);

            // Act
            Action action = () => sut.ReadContent(input, false);

            // Assert
            action.Should().Throw<TypeConverterException>();
        }

        [TestMethod]
        public void Should_ExtractTransFees_Pass_WhenTheDataIsValidAndAvailable()
        {
            // Arrange
            var fixture = new DataExtractorFixture();
            var expected = fixture.ValidOutput;
            var input = new StringReader(fixture.ValidInput);
            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);

            // Act
            var actual = sut.ReadContent(input, false);

            // Assert
            expected.Should().Contain(item => item.TransactionFees == 2.1);
            expected.Length.Should().IsSameOrEqualTo(actual.Length);
            expected[0].Should().IsSameOrEqualTo(actual[0]);
        }

        [TestMethod]
        public void Should_ExtractTransFees_ReturnsNullFor_WhenTransFeesIsNotInTheRightFormat()
        {
            // Arrange
            var fixture = new DataExtractorFixture();
            var input = new StringReader(fixture.InvalidInputTransFees);
            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);

            // Act
            Action action = () => sut.ReadContent(input, false);

            // Assert
            action.Should().Throw<TypeConverterException>();
        }

        [TestMethod]
        public void Should_ExtractTransFees_ReturnError_WhenTransFeesIsEmpty()
        {
            // Arrange
            var fixture = new DataExtractorFixture();
            var input = new StringReader(fixture.EmptyInputTransFees);
            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);

            // Act
            Action action = () => sut.ReadContent(input, false);

            // Assert
            action.Should().Throw<TypeConverterException>();
        }

        [TestMethod]
        public void Should_ExtractOtherFees_Pass_WhenTheDataIsValidAndAvailable()
        {
            // Arrange
            var fixture = new DataExtractorFixture();
            var expected = fixture.ValidOutput;
            var input = new StringReader(fixture.ValidInput);
            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);

            // Act
            var actual = sut.ReadContent(input, false);

            // Assert
            expected.Should().Contain(item => item.OtherFees == 0.1);
            expected.Length.Should().IsSameOrEqualTo(actual.Length);
            expected[0].Should().IsSameOrEqualTo(actual[0]);
        }

        [TestMethod]
        public void Should_ExtractOtherFees_ReturnsNullFor_WhenOtherFeesIsNotInTheRightFormat()
        {
            // Arrange
            var fixture = new DataExtractorFixture();
            var input = new StringReader(fixture.InvalidInputOtherFees);
            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);

            // Act
            Action action = () => sut.ReadContent(input, false);

            // Assert
            action.Should().Throw<TypeConverterException>();
        }

        [TestMethod]
        public void Should_ExtractOtherFees_ReturnError_WhenOtherFeesIsEmpty()
        {
            // Arrange
            var fixture = new DataExtractorFixture();
            var input = new StringReader(fixture.EmptyInputOtherFees);
            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);

            // Act
            Action action = () => sut.ReadContent(input, false);

            // Assert
            action.Should().Throw<TypeConverterException>();
        }

        [TestMethod]
        public void Should_ExtractV3DealId_Pass_WhenTheDataIsValidAndAvailable()
        {
            // Arrange
            var fixture = new DataExtractorFixture();
            var expected = fixture.ValidOutput;
            var input = new StringReader(fixture.ValidInput);
            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);

            // Act
            var actual = sut.ReadContent(input, false);

            // Assert
            expected.Should().Contain(item => item.V3DealId == "02B4EFADE6");
            expected.Length.Should().IsSameOrEqualTo(actual.Length);
            expected[0].Should().IsSameOrEqualTo(actual[0]);
        }

       

        [TestMethod]
        public void Should_ExtractExitDate_Pass_WhenTheDataIsValidAndAvailable()
        {
            // Arrange
            var fixture = new DataExtractorFixture();
            var expected = fixture.ValidOutput;
            var input = new StringReader(fixture.ValidInput);
            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);

            // Act
            var actual = sut.ReadContent(input, false);

            // Assert
            expected.Should().Contain(item => item.ExitDate == Convert.ToDateTime("3/3/2003"));
            expected.Length.Should().IsSameOrEqualTo(actual.Length);
            expected[0].Should().IsSameOrEqualTo(actual[0]);
        }

        [TestMethod]
        public void Should_ExtractExitDate_ReturnsNullForExitDate_WhenExitDateIsNotInTheRightFormat()
        {
            // Arrange
            var fixture = new DataExtractorFixture();
            var input = new StringReader(fixture.InvalidInputExitDate);
            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);

            // Act
            Action action = () => sut.ReadContent(input, false);

            // Assert
            action.Should().Throw<ReaderException>();
        }

        [TestMethod]
        public void Should_ExtractExitDate_ReturnError_WhenExitDateIsEmpty()
        {
            // Arrange
            var fixture = new DataExtractorFixture();
            var input = new StringReader(fixture.EmptyInputExitDate);
            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);

            // Act
            Action action = () => sut.ReadContent(input, false);

            // Assert
            action.Should().Throw<ReaderException>();

        }


        [TestMethod]
        public void Should_Extract_ThrowError_IfDataBeingParsedIsNotInCorrectFormat()
        {
            // Arrange
            var data = new StringReader("help");
            var fixture = new DataExtractorFixture();
            var legacyDataExtractor = Substitute.For<IDataExtractor>();
            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);
            legacyDataExtractor.ReadContent(Arg.Any<StringReader>(), Arg.Any<bool>())
                .Throws(new MissingFieldException(null));

            // Act
            Action action = () => sut.ReadContent(data, false);

            // Assert
            action.Should().Throw<MissingFieldException>();
        }

        [TestMethod]
        public void Should_Extract_ThrowError_IfDataStringBeingParsedIsEmpty()
        {
            // Arrange
            var data = new StringReader(" ");
            var fixture = new DataExtractorFixture();
            var legacyDataExtractor = Substitute.For<IDataExtractor>();
            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);
            legacyDataExtractor.ReadContent(Arg.Any<StringReader>(), Arg.Any<bool>())
                .Throws(new MissingFieldException(null));

            // Act
            Action action = () => sut.ReadContent(data, false);

            // Assert
            action.Should().Throw<MissingFieldException>();
        }
    }
}