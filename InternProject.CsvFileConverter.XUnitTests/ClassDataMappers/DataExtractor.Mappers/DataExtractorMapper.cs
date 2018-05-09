using System.Collections;
using System.Collections.Generic;
using InternProject.CsvFileConverter.Library.Extensions.Mapping;

namespace InternProject.CsvFileConverter.XUnitTests.ClassDataMappers.DataExtractor.Mappers
{
    public class DataExtractorMapper : IEnumerable<object[]>
    {
        public static DealData fixture = new DealData();

        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {fixture.SectorId, 1},
            new object[] {fixture.CountryId, 229},
            new object[] {fixture.OtherFees, 0.1},
            new object[] {fixture.TransactionTypeId, 209},
            new object[] {fixture.TransactionFees, 2.1},
            new object[] {fixture.V3DealId, "02B4EFADE6"}
        };

        public IEnumerator<object[]> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}