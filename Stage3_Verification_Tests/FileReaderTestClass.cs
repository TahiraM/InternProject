using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stage3_Verification;

namespace Stage3_Verification_Tests
{
    [TestClass]
    public  class FileReaderTestClass
    {
        //public abstract IFileReader GetStringSearcherInstance();

        [TestMethod]
        public void ToCheck_IfFileReaderCanReadAFileGivenToIt()
        {
            const string input = "Deal.csv";
            FileReader reader = new FileReader();
            Assert.IsNotNull(reader.ReadContent(input));
        }

        [TestMethod]
        public void ShouldFail_IfileIsNotFound()
        {
            var value = 0;
            const string input = " ";
            if (!File.Exists(input))
            {
                 value = 1;
            }

            Assert.AreEqual(value,1);
        }

        [TestMethod]
        public void ShouldFail_WhenANonCSVFileIsGiven()
        {
            string inputed = "pages.jpg";
            FileReader reader = new FileReader();
            Assert.ThrowsException<FileLoadException>(() => reader.ReadContent(inputed));
        }

    }
}
