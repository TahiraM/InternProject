using CsvFileConvertor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace CsvFileConverterTests
{
    [TestClass]
    public class CsvToJsonConverterTests
    {
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
            sut.Convert("", "");

            // Assert
            fileReader.Received(1).ReadContent(Arg.Any<string>());
            fileWriter.Received(1).WriteContent(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<bool>());
            dataExtractor.Received(1).Extract(Arg.Any<string[]>());
            jsonConverter.Received(1).ConvertToJson(Arg.Any<DealData[]>());
        }
    }
}