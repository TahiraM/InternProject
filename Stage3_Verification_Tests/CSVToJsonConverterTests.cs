//using CsvFileConverter;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NSubstitute;

//namespace CsvFileConverterTests
//{
//    [TestClass]
//    public class CsvToJsonConverterTests
//    {
//        [TestMethod]
//        public void ShouldPass_IfTheInterFaceIsLinkedCOrrectlyAndAMOckInterfaceCanBeCreated()
//        {
//            // Arrange
//            var fileReader = Substitute.For<IDataExtractor>();
//            var fileWriter = Substitute.For<IFileWriter>();
//            var jsonConverter = Substitute.For<IJsonConverter>();
//            var validations = Substitute.For<IValidations>();

//            var sut = new CsvToJsonConverter(fileReader, fileWriter, jsonConverter, validations);

//            // Act
//            sut.Convert("", "");

//            // Assert
//            fileReader.Received(1).ReadContent(Arg.Any<string>());
//            fileWriter.Received(1).WriteContent(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<bool>());
//            jsonConverter.Received(1).ConvertToJson(Arg.Any<DealData[]>());
//        }
//    }
//}