using System;
using System.IO;
using CsvHelper;
using CsvHelper.TypeConversion;
using FluentAssertions;
using FluentAssertions.Common;
using InternProject.CsvFileConverter.Library;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Serilog;
using Xunit;
using MissingFieldException = CsvHelper.MissingFieldException;

namespace InternProject.CsvFileConverter.XUnitTests
{
    public class DataExtractorTests
    {
        [Theory]
        [ClassData(typeof(fixtureData))]
        public void Should_Extract_Fail_WhenDataNotInAcceptableFormat(string data)
        {
            // Arrange
            var fixture = new DataExtractorFixture();
            var input = new StringReader(data);
            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);

            // Act
            Action action = () => sut.ReadContent(input, false);

            //Assert
            action.Should().Throw<TypeConverterException>();
        }

        [Theory]
        [ClassData(typeof(DataExtractorMapper))]
        public void Should_Extract_Pass_WhenTheDataIsValidAndAvailable(object testData, object value)
        {
            // Arrange
            var fixture = new DataExtractorFixture();
            var expected = fixture.ValidOutput;
            var input = new StringReader(fixture.ValidInput);
            var sut = new DataExtractor(fixture.GetValidators(), Log.Logger);

            // Act
            var actual = sut.ReadContent(input, false);

            // Assert
            //expected.Should().Contain(item => item.OtherFees == 0.1);
            testData.Should().IsSameOrEqualTo(value);
            expected.Length.Should().IsSameOrEqualTo(actual.Length);
            expected[0].Should().IsSameOrEqualTo(actual[0]);
        }

        [Theory]
        [InlineData("help")]
        [InlineData(" ")]
        public void Should_Extract_ThrowError_IfDataBeingParsedIsNotInCorrectFormatOrEmpty(string dataString)
        {
            // Arrange
            var data = new StringReader(dataString);
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


        [Fact]
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

        [Fact]
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
    }
}