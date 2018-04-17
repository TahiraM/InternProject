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
//            var data = new DealData { Country = "Canada", Currency = "CAD" };
//            var dataArray = new[] { data };
//            var expected = JsonConvert.SerializeObject(dataArray);

//            var sut = new JsonConverter();

//            // Act
//            var actual = sut.ConvertToJson(dataArray);

//            // Assert
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void Should_ConvertToJson_ThrowTheRightError_WhenTheDependencyFail()
//        {
//            // Arrange

//            var fixture = new LegacyJsonConverterFixture();

//            var sut = new JsonConverter();

//            // Act
//            Action action = () => sut.ConvertToJson(fixture.InValidInput);

//            // Assert
//            Assert.ThrowsException<SystemException>(action);
//        }
//    }
//}