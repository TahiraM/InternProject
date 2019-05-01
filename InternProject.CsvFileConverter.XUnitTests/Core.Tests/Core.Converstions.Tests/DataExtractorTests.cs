using System;
using System.IO;
using CsvHelper;
using CsvHelper.TypeConversion;
using FluentAssertions;
using FluentAssertions.Common;
using InternProject.CsvFileConverter.Library.Core.Conversions;
using InternProject.CsvFileConverter.XUnitTests.ClassDataMappers.DataExtractor.Mappers;
using InternProject.CsvFileConverter.XUnitTests.DataFixtures.Tests;
using Xunit;
using MissingFieldException = CsvHelper.MissingFieldException;

namespace InternProject.CsvFileConverter.XUnitTests.Core.Tests.Core.Converstions.Tests
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
            var sut = new DataExtractor(fixture.GetValidators(), fixture.Logger);

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
            var sut = new DataExtractor(fixture.GetValidators(), fixture.Logger);

            // Act
            var actual = sut.ReadContent(input, false);

            // Assert
            testData.Should().IsSameOrEqualTo(value);
            expected.Length.Should().IsSameOrEqualTo(actual.Length);
            expected[0].Should().IsSameOrEqualTo(actual[0]);
        }

        //[Theory]
        [InlineData("help")]
        [InlineData(" ")]
        public void Should_Extract_ThrowError_IfDataBeingParsedIsNotInCorrectFormatOrEmpty(string dataString)
        {
            // Arrange
            var data = new StringReader(dataString);
            var fixture = new DataExtractorFixture();
            var sut = new DataExtractor(fixture.GetValidators(), fixture.Logger);

            // Act
            Action action = () => sut.ReadContent(data, false);

            // Assert
            action.Should().Throw<ReaderException>();
        }


        [Fact]
        public void Should_ExtractExitDate_Pass_WhenTheDataIsValidAndAvailable()
        {
            // Arrange
            var fixture = new DataExtractorFixture();
            var expected = fixture.ValidOutput;
            var input = new StringReader(fixture.ValidInput);
            var sut = new DataExtractor(fixture.GetValidators(), fixture.Logger);

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
            var sut = new DataExtractor(fixture.GetValidators(), fixture.Logger);

            // Act
            Action action = () => sut.ReadContent(input, false);

            // Assert
            action.Should().Throw<ReaderException>();
        }
    }
}