using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Stage3_Verification;
using JsonConverter = Stage3_Verification.JsonConverter;

namespace Stage3_Verification_Tests
{
    [TestClass]
    public  class FileReaderTestClass
    {
        //public abstract IFileReader GetStringSearcherInstance();

        [TestMethod]
        public void ToCheck_IfFileReaderCanReadAFileGivenToIt()
        {
            const string input = "Deal.csv";
            FileReader reader = new FileReader();
            Assert.IsNotNull(reader.ReadContent(input));
        }

        [TestMethod]
        public void ShouldFail_IfileIsNotFound()
        {
            var value = 0;
            const string input = " ";
            if (!File.Exists(input))
            {
                 value = 1;
            }

            Assert.AreEqual(value,1);
        }

        [TestMethod]
        public void ShouldFail_WhenANonCSVFileIsGiven()
        {
            string inputed = "pages.jpg";
            FileReader reader = new FileReader();
            Assert.ThrowsException<FileLoadException>(() => reader.ReadContent(inputed));
        }


        [TestMethod]
        public void ShouldPass_IfTheInterFaceIsLinkedCOrrectlyAndAMOckInterfaceCanBeCreated()
        {
            // Arrange
            var fileReader = Substitute.For<IFileReader>();
            var fileWriter = Substitute.For<IFileWriter>();
            var dataExtractor = Substitute.For<IDataExtractor>();
            var jsonConverter = Substitute.For<IJsonConverter>();

            var sut = new CsvToJsonConverter(fileReader, fileWriter, dataExtractor, jsonConverter);
            
            // Act
            sut.Convert("","");

            // Assert
            fileReader.Received(1).ReadContent(Arg.Any<string>());
            fileWriter.Received(1).WriteContent(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<bool>());
            dataExtractor.Received(1).Extract(Arg.Any<string[]>());
            jsonConverter.Received(1).ConvertToJson(Arg.Any<DealData[]>());
        }
    }

    [TestClass]
    public class FileReaderTests
    {
        [TestMethod]
        public void Should_ReadContent_Pass_WhenTheCsvFileIsPresentAndContainsTheRightData()
        {
            // Arrange
            var fileName = "samplefile.csv";
            var expected = "Test";
            File.WriteAllText(fileName, expected);

            var sut = new FileReader();

            // Act
            var result = sut.ReadContent(fileName);

            File.Delete(fileName);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Length, 1);
            Assert.AreEqual(result[0], expected);
        }

        [TestMethod]
        public void Should_ReadContent_ThrowTheRightError_WhenTheFileIsPresentButExtensionIsNotCsv()
        {
            // Arrange
            var fileName = "samplefile";
            var expected = "Test";
            File.WriteAllText(fileName, expected);

            var sut = new FileReader();

            // Act
            Action action = () => sut.ReadContent(fileName);

            // Assert
            Assert.ThrowsException<FileLoadException>(action);

            File.Delete(fileName);
        }
    }

    [TestClass]
    public class JsonConverterTests
    {
        [TestMethod]
        public void Should_ConvertToJson_Pass_WhenTheDataIsValidAndAvailable()
        {
            // Arrange
            var data = new DealData() { Country = "Canada", Currency = "CAD"};
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
            Action action = () => sut.ConvertToJson(new DealData[] {});

            // Assert
            Assert.ThrowsException<JsonException>(action);
        }
    }
}
