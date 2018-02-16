using System;
using System.Collections.Generic;
using System.Text;

namespace Stage3_Verification
{
    public interface IDataExtractor
    {
        DealData[] Extract(string[] rows);
    }
}
