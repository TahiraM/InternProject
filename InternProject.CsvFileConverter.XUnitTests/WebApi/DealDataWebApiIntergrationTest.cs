﻿using System;
using System.Threading.Tasks;
using FluentAssertions;
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
        public async Task Should_GetAsync_PassWhenCorrectDataIsBeingPassedThrough()
        {
            // Given
            var expected =
                "{\"v3DealId\":\"02B4EFAD4432\",\"eFrontDealId\":\"02B4EFADE653J8339D13F93EB851943C900\",\"dealName\":\"Marston (Project Magenta)0\",\"v3CompanyId\":\"JFV3CompanyI6\",\"v3CompanyName\":\"JFV3CompanyHellloooo\",\"sectorId\":6,\"sector\":\"Advertising\",\"countryId\":null,\"country\":\"United Kingdom\",\"transactionTypeId\":320,\"transactionType\":\"Primary LBO\",\"transactionFees\":5.3,\"otherFees\":1.1,\"currency\":\"EUR\",\"activeInActive\":\"Active\",\"exitDate\":\"2004-04-04T00:00:00\"}";

            // When

            var response = _fixture.Client.GetAsync("/api/values/02B4EFAD4432").Result;
            var res = "";
            using (var content = response.Content)
            {
                var result = content.ReadAsStringAsync();
                res = result.Result;
            }

            // Then
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(200);
            response.IsSuccessStatusCode.Should().BeTrue();
            res.Should().Be(expected);
        }

        [Fact]
        public async Task Should_PublishAsync_FailWhenIncorrectDataIsBeingPassedThrough()
        {
            // Given
            var expected =
                "{\"v3DealId\":\"02B4EFAD4432\",\"eFrontDealId\":\"02B4EFADE653J8339D13F93EB851943C900\",\"dealName\":\"Marston (Project Magenta)0\",\"v3CompanyId\":\"JFV3CompanyI6\",\"v3CompanyName\":\"JFV3CompanyHellloooo\",\"sectorId\":6,\"sector\":\"Advertising\",\"countryId\":null,\"country\":\"United Kingdom\",\"transactionTypeId\":320,\"transactionType\":\"Primary LBO\",\"transactionFees\":5.3,\"otherFees\":1.1,\"currency\":\"EUR\",\"activeInActive\":\"Active\",\"exitDate\":\"2004-04-04T00:00:00\"}";

            // When

            var response = _fixture.Client.GetAsync("/api/help/fail").Result;
            var res = "";
            using (var content = response.Content)
            {
                var result = content.ReadAsStringAsync();
                res = result.Result;
            }

            // Then
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(404);
            response.IsSuccessStatusCode.Should().BeFalse();
        }
    }
}