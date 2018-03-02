using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Stage3_Verification;

namespace Stage3_Verification_Tests
{
    [TestClass]
    public class DealExtractorTest
    {
        [TestMethod]
        public void ShouldPass_TheNumberOfRowsShouldBeTakenFromIDataExtractor()
        {
            var dataExtractorMock = new Mock<IDataExtractor>();

            dataExtractorMock.Setup(data => data.Extract(It.IsAny<string[]>()));
            var dataExtract = new DataExtractor();
            string[] testData= { "hello", "hi", "yes", "no" };
            var extractions = dataExtract.Extract(testData);
            Assert.AreSame(extractions, "4");
        }
    }
}
