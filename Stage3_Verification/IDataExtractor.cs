﻿namespace Stage3_Verification
{
    public interface IDataExtractor
    {
        DealData[] Extract(string[] rows);
    }
}