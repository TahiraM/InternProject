//using System.IO;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NSubstitute;
//using Stage3_Verification;
//
//namespace Stage3_Verification_Tests
//{
//    public void TestSetUp()
//    {
//    _dataExtractor = Substitute.For<IDataExtractor>();
//    _dataToJsonConverter = Substitute.For<IJsonConverter>();
//    _fileReader = Substitute.For<IFileReader>();
//    _fileWriter = Substitute.For<IFileWriter>();
//
//
//    }
//    [TestClass]
//    public class JsonConverterTests
//    {
//        //create some mock data to ensure that the json converter class is working correctly? 
//        [TestMethod]
//        public void ShouldPass_IfTheStringBuilderStringIsNotNull()
//        {
//            //Arrange
//            string expectedData = "[{ \"V3DealId\":\"02B4EFADE6\",\"EFrontDealId\":\"02B4EFADE60B48339D13F93EB851943C\",\"DealName\":\"Marston (Project Magenta)\",\"V3CompanyId\":\"\",\"V3CompanyName\":\"\",\"SectorId\":\"\",\"Sector\":\"0\",\"CountryId\":\"United Kingdom\",\"Country\":\"229\",\"TransactionTypeId\":\"\",\"TransactionType\":\"0\",\"TransactionFees\":\"98.76\",\"OtherFees\":\"0\",\"Currency\":\"EUR\",\"ActiveInActive\":\"Active\",\"ExitDate\":\"1st\"},{ \"V3DealId\":\"02B4EFADE6\",\"EFrontDealId\":\"02B4EFADE60B48339D13F93EB851943C\",\"DealName\":\"Marston (Project Magenta)\",\"V3CompanyId\":\"JFV3CompanyId02B4EFADE6\",\"V3CompanyName\":\"JFV3Company\",\"SectorId\":\"Advertising\",\"Sector\":\"1\",\"CountryId\":\"United Kingdom\",\"Country\":\"229\",\"TransactionTypeId\":\"Primary LBO\",\"TransactionType\":\"209\",\"TransactionFees\":\"0\",\"OtherFees\":\"0\",\"Currency\":\"EUR\",\"ActiveInActive\":\"false\",\"ExitDate\":\"2nd\"},{ \"V3DealId\":\"02B4EFADE6\",\"EFrontDealId\":\"02B4EFADE60B48339D13F93EB851943C\",\"DealName\":\"Marston (Project Magenta)\",\"V3CompanyId\":\"JFV3CompanyId02B4EFADE6\",\"V3CompanyName\":\"JFV3Company\",\"SectorId\":\"Advertising\",\"Sector\":\"1\",\"CountryId\":\"United Kingdom\",\"Country\":\"229\",\"TransactionTypeId\":\"Primary LBO\",\"TransactionType\":\"209\",\"TransactionFees\":\"2.1\",\"OtherFees\":\"0.1\",\"Currency\":\"EUR\",\"ActiveInActive\":\"Active\",\"ExitDate\":\"3rd\"}]";
//
//            var sut = new CsvToJsonConverter(_fileReader, _fileWriter, _dataExtractor,
//                _dataToJsonConverter);
//
//            //Act
//            var testData = _dataToJsonConverter.ConvertToJson(MockDataMethod());
//
//            //Assert
//            Assert.AreEqual(expectedData, testData);
//            //Assert.IsNotNull(_fileWriter.WriteContent("Output", "data"));
//        }
//    }
//}
