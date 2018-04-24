using System.Collections;
using System.Collections.Generic;

namespace InternProject.CsvFileConverter.XUnitTests
{
    public class fixtureData : IEnumerable<object[]>
    {
        public static DataExtractorFixture fixture = new DataExtractorFixture();

        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {fixture.InvalidInputSectorId},
            new object[] {fixture.InvalidInputCountryId},
            new object[] {fixture.InvalidInputOtherFees},
            new object[] {fixture.InvalidInputTransTypeId},
            new object[] {fixture.InvalidInputTransFees},

            new object[] {fixture.EmptyInputSectorId},
            new object[] {fixture.EmptyInputCountryId},
            new object[] {fixture.EmptyInputOtherFees},
            new object[] {fixture.EmptyInputTransTypeId},
            new object[] {fixture.EmptyInputTransFees}
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