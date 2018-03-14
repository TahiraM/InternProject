using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Stage3_Verification;

namespace Stage3_Verification_Tests
{
    [TestClass]
    public class LegacyDataExtractorTest
    {
        [TestMethod]
        public void Should_Extract_Pass_WhenTheDataIsValidAndAvailable()
        {
            // Arrange
            var fixture = new LegacyDataExtractorFixture();
            var expected = fixture.ValidOutput;
            var sut = new LegacyDataExtractor();

            // Act
            var actual = sut.ExtractWithoutHeader(fixture.ValidInput);
            //var actual = sut.Extract(fixture.ValidInput, false);

            // Assert
            Assert.AreEqual(expected.Length, actual.Length);
            Assert.AreEqual(expected[0].SectorId, actual[0].SectorId);
        }

        [TestMethod]
        public void Should_Extract_ReturnsNullForSectorId_WhenSectorIdIsNotInTheRightFormat()
        {
            // Arrange
            var fixture = new LegacyDataExtractorFixture();
            var sut = new LegacyDataExtractor();

            // Act
            Action action = () => sut.Extract(fixture.InvalidInputForSector, false);

            // Assert
            Assert.ThrowsException<FormatException>(action);
        }
    }
}