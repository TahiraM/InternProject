using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stage3_Verification;

namespace Stage3_Verification_Tests
{
    [TestClass]
    public class FileWriterTestClass
    {
        [TestMethod]
        public void ShouldPass_IfFileIsNotAvailable_OverrideIfFileIfFileIsAvailable()
        {
            //first check if file is there if it is assert that it has been overwritten
            //If file not there assert and check it is created and written in 

            if (File.Exists("Vali.json"))
            {
                Assert.IsNotNull("Vali.json");
            }else
            {
                FileWriter write = new FileWriter();
                write.WriteContent("Vali.json", "hjhfHFUhfuuEFHUHFhjhh");
                Assert.IsTrue(File.Exists("Vali.json"));
                Assert.IsNotNull("Vali.json");
            }
        }
    }
}
