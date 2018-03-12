using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stage3_Verification;

namespace Stage3_Verification_Tests
{
    [TestClass]
    public class ValidationsOfStringsTests
    {
        [TestMethod]
        public void ShouldPass_IfAnIntIsPassedThroughTheIntValidator()
        {
            var intergerTest = ValidationOfStrings.ThisInt("8");
            Assert.AreEqual(intergerTest, 8);
        }

        [TestMethod]
        public void ShouldPass_IfAnDoubleIsPassedThroughTheIntValidator()
        {
            var doubleTest = ValidationOfStrings.ThisDouble("0.987");
            Assert.AreEqual(doubleTest, 0.987);
        }
    }
}