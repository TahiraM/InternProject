using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using Stage3_Verification;
using NSubstitute;
using NSubstitute.Core;
using NSubstitute.ExceptionExtensions;
using JsonConverter = Stage3_Verification.JsonConverter;

namespace Stage3_Verification_Tests
{
    [TestClass]
    public class DataExtractorTest
    {
        

       


        [TestMethod]
        public void ShouldPass_TheNumberOfRowsShouldBeTakenFromIDataExtractor()
        {
            // Arrange
            var data = new[] { "V3DealID||eFrontDealID", "V3DealID||eFrontDealID" };
            var expected = new DealData[2];

            var legacyDataExtractor = Substitute.For<ILegacyDataExtractor>();
            legacyDataExtractor.Extract(Arg.Any<string[]>()).Returns(expected);

            var sut = new DataExtractor(legacyDataExtractor);

            // Act
            var actual = sut.Extract(data);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
