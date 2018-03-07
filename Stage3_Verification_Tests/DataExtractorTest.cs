﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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


        [TestMethod]
        public void ShouldPass_TheNumberOfRowsShouldBeTakenFromIDataExtractor()
        {
            _dataExtractor = Substitute.For<IDataExtractor>();
            _dataToJsonConverter = Substitute.For<IJsonConverter>();
            _fileReader = Substitute.For<IFileReader>();
            _fileWriter = Substitute.For<IFileWriter>();

            var sut = new CsvToJsonConverter(_fileReader, _fileWriter, _dataExtractor,
                _dataToJsonConverter);



            //Assert.IsNotNull(_fileWriter.WriteContent("Output", "data"));
        }
    }
}
