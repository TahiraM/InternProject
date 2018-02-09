using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stage3_Verification;

namespace CsvToJsonTests
{
    [TestClass]
    public class ExtractionTests
    {
        [TestMethod]
        public void Should_CheckTheProjectToFindCSVFile_IsPresentWhenTheProjectRunInStartup()
        {
            var i = 0;
            var result = 1;
            if (File.Exists(Extraction.FileType)) i++;

            Assert.AreEqual(i, result);
        }

        [TestMethod] //test to check csv file is being called
        public void Should_FileType_ReturnsTheCorrectFileWithCsvExtension_WhenTheProjectRunInStartup()
        {
            var name = Extraction.FileType;
            var csv = ".csv";
            StringAssert.Contains(name, csv);
        }

        [TestMethod] //test to check csv file is being read with no errors 
        public void Should_CHeckToSeeIfCSVFileParsedIntoString_WhenTheProjectRunInStartup()
        {
            var content = Extraction.CsvFileReader().ToString();
            Assert.IsNotNull(content);
        }

        [TestMethod] //test to check the file is being split in correct number of rows
        public void Should_CheckToSeeIfDataIsSplitIntoCorrectNumberOfRows_WhenTheProjectRunInStartup()
        {
            var rownumber = Extraction.NumberofRows().Length;
            var actualNum = 3;
            Assert.AreEqual(rownumber, actualNum);
        }

        [TestMethod] // test to see the file is being split to the correct number of headings/values in each row
        public void Should_CheckToSeeIfDataIsSplitIntoCorrectNumberOfColumns_WhenTheProjectRunInStartup()
        {
            var actualNum = 16;
            var testNum = Extraction.RowValueString(0).Length;
            Assert.AreEqual(actualNum, testNum);
        }

        [TestMethod] //test to check Json file is created and saved into the project
        public void Should_CheckTheProjectToFindIfJsonFileISCreated_CheckIfJSONIsPresentWhenTheProjectRun()
        {
            var i = 0;
            var result = 1;
            if (File.Exists(Extraction.FileJsonType)) i = 1;

            Assert.AreEqual(i, result);
        }

        [TestMethod] //test to check the Json file can be accessed and read
        public void Should_CHeckToSeeIf_JSONBeingRead_FileParsedIntoString_WhenTheProjectRun()
        {
            var content = Extraction.JsonFileReader();
            Assert.IsNotNull(content);
        }

        [TestMethod] //test to check that the csv conversion is linking the correct header to value for the data
        public void Should_CHeckToSeeIfDataMappingIsCorrect_HeaderToData_WhenTheProjectRun()
        {
            var content = Extraction.HeaderToDataMapping().ToString();
            const string match = "\"" + "V3DealID" + "\":" + "\"" + "02B4EFADE6" + "\"";
            StringAssert.Contains(content, match);
        }

        [TestMethod]
        public void ShouldCheck_IfAStringIsPutThroughIntValidationTest_WillFail()
        {
            Assert.ThrowsException<FormatException>(() => Validations.Integer_Validator("hello"));
        }

        [TestMethod]
        public void ShouldCheck_IfAStringIsPutThroughDoubleValidationTest_WillFail()
        {
            Assert.ThrowsException<FormatException>(() => Validations.Double_Validation("hello"));
        }

        [TestMethod]
        public void ShouldCheck_IfAIntegerPutThroughIntValidationTest_WillPass()
        {
            Assert.IsNotNull(Extraction.ValidationOfInterger(1, 7));
        }

        [TestMethod]
        public void ShouldCheck_IfADoublePutThroughDoubleValidationTest_WillPass()
        {
            Assert.IsNotNull(Extraction.ValidationOfDouble(1,12));
        }

        [TestMethod]
        public void ShouldCheck_IfAStringIsPutThroughStringValidationTest_WillPass()
        {
            Assert.IsNotNull(Extraction.ValidationOfString(1,2));
        }
    }
}