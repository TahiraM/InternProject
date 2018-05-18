using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;

namespace InternProject.CsvFileConverter.XUnitTests.WebApi
{
    public class DealDataWebApiIntergrationTest
    {
        [Theory]
        [InlineData("Files\\QPR_Sample.xlsx", "UK Team", 2, "ATPI", @"Reports\QPR_Sample.xlsx")]
        [InlineData("Files\\Valuation_Sample.xlsx", "UK Team", 2, "ATPI",  @"Valuations\Valuation_Sample.xlsx")]
        public async Task Should_PublishAsync_PassWhenFilePathIsValid(
            string sourceFile,
            string dealTeamName,
            int companyId,
            string companyName,
            string expectedPath)
        {
            // Given
            

            //var expected =
            //    $@"\\icgplc.com\icg\afs\AppTemp\Mezz\DealAssets\{dealTeamName}\{companyName}\Company Information\Monitoring & QPR\{expectedPath}";

            //var stringContent = new StringContent(JsonConvert.SerializeObject(publishItem), Encoding.UTF8,
            //    "application/json");

            //// When
            //var actual = await _fixture.Client.PostAsync($"/api/v1/companies/{companyId}/assets", stringContent);

            //// Then
            //actual.Should().NotBeNull();
            //actual.IsSuccessStatusCode.Should().BeTrue();

            //var content = await actual.Content.ReadAsStringAsync();
            //var result = JsonConvert.DeserializeObject<PublishResult>(content);

            //result.PublishedItemPath.Should().Be(expected);
            //File.Exists(result.PublishedItemPath).Should().BeTrue();

            //// Clean up
            //File.Delete(result.PublishedItemPath);
        }
    }
}
