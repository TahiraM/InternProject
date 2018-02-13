using System;
using System.Collections.Generic;
using System.Text;

namespace Stage3_Verification
{
    public interface IJsonConverter
    {
        string ConvertToJson(FundData[] data);
    }
}
