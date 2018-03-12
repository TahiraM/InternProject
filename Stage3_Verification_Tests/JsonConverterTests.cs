using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Stage3_Verification;
using JsonConverter = Stage3_Verification.JsonConverter;

namespace Stage3_Verification_Tests
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
}