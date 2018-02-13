using System;
using System.Collections.Generic;
using System.Text;

namespace Stage3_Verification
{
    public interface IFileWriter
    {
        void WriteContent(string output, string data);
    }
}
