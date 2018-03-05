using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Stage3_Verification;
using NSubstitute;

namespace Stage3_Verification_Tests
{
    [TestClass]
    public class DataExtractorTest
    {
        [TestMethod]
        public void ShouldPass_TheNumberOfRowsShouldBeTakenFromIDataExtractor()
        {
            var testingDataExtractor = new DataExtractor();
            var dataExtractor = Substitute.For<IDataExtractor>();
            dataExtractor.Extract


        }
    }
}
