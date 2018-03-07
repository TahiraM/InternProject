using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Stage3_Verification;
using NSubstitute;

namespace Stage3_Verification_Tests
{
    [TestClass]
    public class DataExtractorTest
    {
        private IDataExtractor _dataExtractor;
        private IJsonConverter _dataToJsonConverter;
        private IFileReader _fileReader;
        private IFileWriter _fileWriter;

        [TestInitialize]
        public void TestSetUp()
        {
            _dataExtractor = Substitute.For<IDataExtractor>();
            _dataToJsonConverter = Substitute.For<IJsonConverter>();
            _fileReader = Substitute.For<IFileReader>();
            _fileWriter = Substitute.For<IFileWriter>();

            
        }

        public DealData[] MockDataMethod()
        {
            var funds = new List<DealData>();
            var mockArray = _fileReader.ReadContent("Deal.csv");
            var rows = mockArray.Returns(x => x.Arg<string[]>());
            for (var i = 1; i <= rows.ToString().Length - 1; i++)
            {
                var data = rows.ToString().Split("||");

                var fund = new DealData
                {
                    V3DealId = data[0],
                    EFrontDealId = data[1],
                    DealName = data[2],
                    V3CompanyId = data[3],
                    V3CompanyName = data[4],
                    SectorId = ValidationOfStrings.ThisInt(data[5]),
                    Sector = data[6],
                    CountryId = ValidationOfStrings.ThisInt(data[7]),
                    Country = data[8],
                    TransactionTypeId = ValidationOfStrings.ThisInt(data[9]),
                    TransactionType = data[10],
                    TransactionFees = ValidationOfStrings.ThisDouble(data[11]),
                    OtherFees = ValidationOfStrings.ThisDouble(data[12]),
                    Currency = data[13],
                    ActiveInActive = data[14],
                    ExitDate = data[15]
                };
                funds.Add(fund);
            }


            return funds.ToArray();
        }


        [TestMethod]
        public void ShouldPass_TheNumberOfRowsShouldBeTakenFromIDataExtractor()
        {
            
        }
    }
}
