using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsvFileConverterTests.TestClasses
{
    [TestClass]
    class DealDataMapperTests
    {
        [TestMethod]
        public void ShouldPass_Validate_IfAllDataBeingTestedIsInCorrectFormat()
        {
            var fixture = new DataExtractorFixture();
            var validators = fixture.GetValidators();

        }
    }
}
