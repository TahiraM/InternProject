using System.IO;
using FluentAssertions;
using FluentAssertions.Common;
using InternProject.CsvFileConverter.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsvFileConverterTests
{
    [TestClass]
    public class FileWriterTests
    {
        [TestMethod]
        public void Should_WriteContent_Pass_WhenTheJsonFileIsPresentAndContainsTheRightData()
        {
            // Arrange
            var fileName = "testing.json";
            var fixture = new FileWriterFixture();
            var actual = fixture.ValidOutput;
            var expected = fixture.ValidInput;
            var sut = new FileWriter(fixture.GetFormatters());

            // Act
            sut.WriteContent(fileName, expected);
            var result = File.ReadAllLines(fileName);


            // Assert
            result.Should().NotBeNullOrEmpty();
            result[0].Should().IsSameOrEqualTo(actual);
            File.Exists(fileName).Should().BeTrue();
            result[0].Should().StartWith("[{").And.EndWith("}]");
        }


        [TestMethod]
        public void ShouldPass_FileBeingSavedIsBeingSavedInCorrectLocation()
        {
            // Arrange
            var fixture = new FileWriterFixture();
            const string fileName = "Vali.json";
            var expected = fixture.ValidInput;
            const string expecPath =
                "Vali.json";
            var sut = new FileWriter(fixture.GetFormatters());

            // Act
            sut.WriteContent(fileName, expected);
            var filePath = Path.GetFullPath(fileName);

            // Assert
            expecPath.Should().IsSameOrEqualTo(filePath);
        }


        [TestMethod]
        public void ShouldPass_WriteContent_DataShouldBeConvertedToXML()
        {
            // Arrange
            var fileName = "testing.xml";
            var fixture = new FileWriterFixture();
            var expected = fixture.InValidInput;
            var sut = new FileWriter(fixture.GetFormatters());

            // Act
            sut.WriteContent(fileName, expected);
            var result = File.ReadAllLines(fileName);

            // Assert
            result.Should().NotBeNullOrEmpty();
            File.Exists(fileName).Should().BeTrue();
            ;
        }

        [TestMethod]
        public void ShouldPass_WriteContent_DataShouldBeConvertedWithOverwriteParameter()
        {
            // Arrange
            var fileName = "testing.json";
            var fixture = new FileWriterFixture();
            var expected = fixture.InValidInput;
            var sut = new FileWriter(fixture.GetFormatters());

            // Act
            sut.WriteContent(fileName, expected, true);
            var result = File.ReadAllLines(fileName);

            // Assert
            result.Should().NotBeNullOrEmpty();
            File.Exists(fileName).Should().BeTrue();
            ;
        }

        [TestMethod]
        public void ShouldPass_WriteContent_DataShouldBeConvertedWithFormatterParameter()
        {
            // Arrange
            var fileName = "testing.xml";
            var fixture = new FileWriterFixture();
            var expected = fixture.InValidInput;
            var sut = new FileWriter(fixture.GetFormatters());

            // Act
            sut.WriteContent(fileName, expected, true, FormatterType.Xml);
            var result = File.ReadAllLines(fileName);

            // Assert
            result.Should().NotBeNullOrEmpty();
            File.Exists(fileName).Should().BeTrue();
            ;
        }
    }
}