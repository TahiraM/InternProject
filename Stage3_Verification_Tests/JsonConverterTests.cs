using System;
using CsvFileConvertor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using JsonConverter = CsvFileConvertor.JsonConverter;

namespace CsvFileConverterTests
{
    [TestClass]
    public class JsonConverterTests
    {
        [TestMethod]
        public void Should_ConvertToJson_Pass_WhenTheDataIsValidAndAvailable()
        {
            // Arrange
            var data = new DealData {Country = "Canada", Currency = "CAD"};
            var dataArray = new[] {data};
            var expected = JsonConvert.SerializeObject(dataArray);

            var legacyJsonConverter = Substitute.For<ILegacyJsonConverter>();
            legacyJsonConverter.Convert(Arg.Any<DealData[]>()).Returns(expected);

            var sut = new JsonConverter(legacyJsonConverter);

            // Act
            var actual = sut.ConvertToJson(dataArray);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_ConvertToJson_ThrowTheRightError_WhenTheDependencyFail()
        {
            // Arrange

            var legacyJsonConverter = Substitute.For<ILegacyJsonConverter>();
            legacyJsonConverter.Convert(Arg.Any<DealData[]>()).Throws(new Exception("Data Is Not Valid"));

            var sut = new JsonConverter(legacyJsonConverter);

            // Act
            Action action = () => sut.ConvertToJson(new DealData[] { });

            // Assert
            Assert.ThrowsException<JsonException>(action);
        }
    }





    [TestClass]
    public class LegacyJsonConverterTests
    {
        // TODO: Create a test to check if data is being mapped correctly
        // TODO: Create a test to check if output data is in correct json format

        [TestMethod]
        public void Should_Convert_Pass_WhenTheDataIsValidAndAvailable()
        {
            // Arrange
            var fixture = new LegacyJsonConverterFixture();
            var sut = new LegacyJsonConverter();

            // Act
            var actual = fixture.ValidOutput;
            var expected = sut.Convert(fixture.ValidInput);
            // Assert
            Assert.AreEqual(actual,expected);
        }

        //public void Should_Convert_Fail_WhenTheDataIsInTheCorrectOrder()
        //{

        //}


    }


    public class LegacyJsonConverterFixture
    {
        public LegacyJsonConverterFixture()
        {
            ValidInput = new []
            {
                new DealData
                {
                    V3DealId = "02B4EFADE6",
                    EFrontDealId = "02B4EFADE60B48339D13F93EB851943C",
                    DealName = "Marston (Project Magenta)",
                    V3CompanyId = "",
                    V3CompanyName = "",
                    SectorId = 3,
                    Sector = "",
                    CountryId = 229,
                    Country = "United Kingdom",
                    TransactionTypeId = 1,
                    TransactionType = "",
                    TransactionFees = 98.76,
                    OtherFees = 0.998,
                    Currency = "EUR",
                    ActiveInActive = "Active",
                    ExitDate = "1/1/2001"
                }

            };

            InValidInput = new[]
            {
                new DealData
                {
                    V3DealId = "02B4EFADE6",
                    EFrontDealId = "02B4EFADE60B48339D13F93EB851943C",
                    DealName = "Marston (Project Magenta)",
                    V3CompanyId = "",
                    V3CompanyName = "",
                    SectorId = 0,
                    Sector = " ",
                    CountryId = 229,
                    Country = "United Kingdom",
                    TransactionTypeId = 1,
                    TransactionType = " ",
                    TransactionFees = 9.0,
                    OtherFees = 0.998,
                    Currency = "EUR",
                    ActiveInActive = "Active",
                    ExitDate = "1/1/2001"
                }

            };

            ValidOutput = GenerateOutput();




        }

        public DealData[] ValidInput { get; }
        public string ValidOutput { get; }
        public DealData[] InValidInput { get; }

        private string GenerateOutput()
        {
            return
                "[{\"V3DealId\":\"02B4EFADE6\",\"EFrontDealId\":\"02B4EFADE60B48339D13F93EB851943C\",\"DealName\":\"Marston (Project Magenta)\",\"V3CompanyId\":\"\",\"V3CompanyName\":\"\",\"SectorId\":\"\",\"Sector\":\"3\",\"CountryId\":\"United Kingdom\",\"Country\":\"229\",\"TransactionTypeId\":\"\",\"TransactionType\":\"1\",\"TransactionFees\":\"98.76\",\"OtherFees\":\"0.998\",\"Currency\":\"EUR\",\"ActiveInActive\":\"Active\",\"ExitDate\":\"1/1/2001\"}]";
        }

    }
}