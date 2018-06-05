using System;
using System.Threading.Tasks;
using FluentAssertions;
using InternProject.CsvFileConverter.Library.Extensions.Mapping;
using Newtonsoft.Json;
using Xunit;

namespace InternProject.CsvFileConverter.XUnitTests.WebApi
{
    public class DealDataWebApiIntergrationTest : IClassFixture<ControllerFixture>
    {
        public DealDataWebApiIntergrationTest(ControllerFixture fixture)
        {
            _fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));
        }

        private readonly ControllerFixture _fixture;

        [Fact]
        public async Task Should_GetAsync_PassWhenCorrectDataIsGottenThroughTheApi()
        {
            // Given
            var expectedString =
                "{\"v3DealId\":\"02B4EFAD4432\",\"eFrontDealId\":\"02B4EFADE653J8339D13F93EB851943C900\",\"dealName\":\"Marston (Project Magenta)0\",\"v3CompanyId\":\"JFV3CompanyI6\",\"v3CompanyName\":\"JFV3CompanyHellloooo\",\"sectorId\":6,\"sector\":\"Advertising\",\"countryId\":159,\"country\":\"United Kingdom\",\"transactionTypeId\":320,\"transactionType\":\"Primary LBO\",\"transactionFees\":5.3,\"otherFees\":1.1,\"currency\":\"EUR\",\"activeInActive\":\"Active\",\"exitDate\":\"2004-04-04T00:00:00\"}";
            var expected = JsonConvert.DeserializeObject<DealData>(expectedString);

            _fixture.Context.Set<DealData>().Add(expected);
            await _fixture.Context.SaveChangesAsync();

            // When
            var response = await _fixture.Client.GetAsync($"api/v1/deals/02B4EFAD4432");

            // Then
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(200);
            response.IsSuccessStatusCode.Should().BeTrue();

            var result = await response.Content.ReadAsStringAsync();
            var actual = JsonConvert.DeserializeObject<DealData>(result);

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task Should_PublishAsync_FailWhenIncorrectDataIsBeingPassedThrough()
        {
            // Given
            var response = await _fixture.Client.GetAsync("/api/help/fail");

            // When
            var result = response.Content.Headers;

            // Then
            result.Should().BeEmpty();
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(404);
            response.IsSuccessStatusCode.Should().BeFalse();
        }
    }
}