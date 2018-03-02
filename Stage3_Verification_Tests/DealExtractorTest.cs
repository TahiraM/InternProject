using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Stage3_Verification;

namespace Stage3_Verification_Tests
{
    [TestClass]
    class DealExtractorTest
    {
        [TestMethod]
        public void ShouldPass_TheNumberOfRowsShouldBeTakenFromIDataExtractor()
        {
            var dataExtractorMock = new Mock<IDataExtractor>();

            dataExtractorMock.Setup(data => data.);
        }
    }
}
