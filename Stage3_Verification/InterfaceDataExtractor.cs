using System;
using System.Collections.Generic;
using System.Text;

namespace Stage3_Verification
{
    public interface IDataExtractor
    {
        FundData[] Extract(string[] content);
    }
}
