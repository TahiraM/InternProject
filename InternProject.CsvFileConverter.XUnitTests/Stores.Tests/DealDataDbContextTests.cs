﻿using System.Linq;
using FluentAssertions;
using FluentAssertions.Common;
using InternProject.CsvFileConverter.Library.Extensions.Mapping;
using InternProject.CsvFileConverter.XUnitTests.DataFixtures.Tests;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace InternProject.CsvFileConverter.XUnitTests.Stores.Tests
{
    public class DealDataDbContextTests
    {
        [Fact]
        public void Should_Pass_WhenCorrectDataIsSavedToDatabase()
        {
            // Arrange
            var fixture = new FileWriterFixture().ValidInput;

            using (var db = new DbContextFixture())
            {
                db.Database.EnsureCreated();
                foreach (var data in fixture)
                {
                    // Act
                    var loaded = db.Set<DealData>()
                        .AsNoTracking()
                        .FirstOrDefault(d => d.V3DealId == data.V3DealId);

                    if (loaded == null)
                        db.Set<DealData>().Add(data);
                    else
                        db.Set<DealData>().Update(data);

                    var result = db.Set<DealData>().Find(data.V3DealId).CountryId;

                    // Assert
                    result.Should().NotBeNull();
                    result.Should().HaveValue();
                    result.Should().IsSameOrEqualTo(129);
                }
            }
        }
    }
}