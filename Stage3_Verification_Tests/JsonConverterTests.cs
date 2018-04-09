//using System;
//using CsvFileConverter;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Newtonsoft.Json;
//using NSubstitute;
//using NSubstitute.ExceptionExtensions;
//using JsonConverter = CsvFileConverter.JsonConverter;

//namespace CsvFileConverterTests
//{
//    [TestClass]
//    public class JsonConverterTests
//    {
//        [TestMethod]
//        public void Should_ConvertToJson_Pass_WhenTheDataIsValidAndAvailable()
//        {
//            // Arrange
//            var data = new DealData {Country = "Canada", Currency = "CAD"};
//            var dataArray = new[] {data};
//            var expected = JsonConvert.SerializeObject(dataArray);

//            var legacyJsonConverter = Substitute.For<ILegacyJsonConverter>();
//            legacyJsonConverter.ConvertToJson(Arg.Any<DealData[]>()).Returns(expected);

//            var sut = new JsonConverter(legacyJsonConverter);

//            // Act
//            var actual = sut.ConvertToJson(dataArray);

//            // Assert
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void Should_ConvertToJson_ThrowTheRightError_WhenTheDependencyFail()
//        {
//            // Arrange

//            var legacyJsonConverter = Substitute.For<ILegacyJsonConverter>();
//            legacyJsonConverter.ConvertToJson(Arg.Any<DealData[]>()).Throws(new SystemException("Data Is Not Valid"));

//            var sut = new JsonConverter(legacyJsonConverter);

//            // Act
//            Action action = () => sut.ConvertToJson(new DealData[] { });

//            // Assert
//            Assert.ThrowsException<SystemException>(action);
//        }
//    }
//}