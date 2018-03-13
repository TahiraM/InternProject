using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Stage3_Verification;

namespace Stage3_Verification_Tests
{
    [TestClass]
    public class DataExtractorTest
    {
        [TestMethod]
        public void Should_Extract_Pass_WhenTheDataIsValidAndAvailable()
        {
            // Arrange
            var file = File.ReadAllLines("Deal.csv").ToString();
            var data = new[] {file};
            var extractData = new LegacyDataExtractor();
            var expected = extractData.Extract(data);

            var legacyDataExtractor = Substitute.For<ILegacyDataExtractor>();
            legacyDataExtractor.Extract(Arg.Any<string[]>()).Returns(expected);

            var sut = new DataExtractor(legacyDataExtractor);

            // Act
            var actual = sut.Extract(data);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_Extract_ThrowError_IfDataBeingParsedIsNotInCorrectFormat()
        {
            // Arrange
            var data = new[] {"help", "hi", "test"};

            var legacyDataExtractor = Substitute.For<ILegacyDataExtractor>();
            var sut = new DataExtractor(legacyDataExtractor);
            legacyDataExtractor.Extract(Arg.Any<string[]>()).Throws(new FormatException("Data Is Not Valid"));

            // Act
            Action action = () => sut.Extract(data);

            // Assert
            Assert.ThrowsException<FormatException>(action);
        }

        [TestMethod]
        public void Should_Extract_ThrowError_IfDataStringBeingParsedIsEmpty()
        {
            // Arrange
            var data = new[] { string.Empty };

            var legacyDataExtractor = Substitute.For<ILegacyDataExtractor>();
            var sut = new DataExtractor(legacyDataExtractor);
            legacyDataExtractor.Extract(Arg.Any<string[]>()).Throws(new FormatException("Data Is Not Valid"));

            // Act
            Action action = () => sut.Extract(data);

            // Assert
            Assert.ThrowsException<FormatException>(action);
        }

        //[TestMethod]
        //public void Should_Extract_Fail_WhenSectorIdValidatorFails()
        //{
        //    // Arrange
        //    var data = new[] {"", "02B4EFADE6 || 02B4EFADE60B48339D13F93EB851943C || Marston(Project Magenta) || JFV3CompanyId02B4EFADE6 || JFV3Company || nope || Advertising || 229 || United Kingdom || 209 || Primary LBO || 2.1 || 0.1 || EUR || Active || 03 / 03 / 03" };
        //    var extractData = new LegacyDataExtractor();
        //    var expected = extractData.Extract(data);
        //    var legacyDataExtractor = Substitute.For<ILegacyDataExtractor>();
        //    var sut = new DataExtractor(legacyDataExtractor);
        //    legacyDataExtractor.Extract(Arg.Is(data)).Returns(expected);


        //    // Act
        //    Action action = () => sut.Extract(data);

        //    // Assert
        //    Assert.ThrowsException<FormatException>(action);
        //}
    }
}