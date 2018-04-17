using CsvFileConverter;
using CsvFileConverter.MainProgramme;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Xunit;
using Xunit.Abstractions;

namespace CsvFileConverterTests
{
    [TestClass]
    public class CsvToJsonConverterTests
    {
        [TestMethod]
        public void ShouldPass_IfTheInterFaceIsLinkedCOrrectlyAndAMOckInterfaceCanBeCreated()
        {
            //// Arrange
            //var fileReader = Substitute.For<IFileReader>();
            //var dataExtractor = Substitute.For<IDataExtractor>();
            //var fileWriter = Substitute.For<IFileWriter>();
            //var jsonConverter = Substitute.For<IJsonConverter>();
            //var validations = Substitute.For<IValidations>();

            //var sut = new CsvToJsonConverter(fileReader, dataExtractor, jsonConverter, validations, fileWriter);

            //// Act
            //sut.Format("", "");

            //// Assert
            //fileReader.Received(1).ReadContent(Arg.Any<string>());
            //fileWriter.Received(1).WriteContent(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<bool>());
            //jsonConverter.Received(1).ConvertToJson(Arg.Any<DealData[]>());
        }
    }

}