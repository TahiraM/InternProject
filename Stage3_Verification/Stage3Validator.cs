﻿using System.IO;
using Castle.Core.Internal;

namespace CsvFileConvertor
{
    public class Stage3Validator
    {
        public int Length { get; set; }
        public string Input { get; set; }
        

        public void StringLength( int stringMaxLength)
        {
            if (Length != stringMaxLength) throw new InvalidDataException("String length too short");
        }

        public void Required(string input)
        {
            var logger = NLog.LogManager.GetCurrentClassLogger();
            if (input.IsNullOrEmpty()) logger.Error(string.Format("This field is neccesary", input.IsNullOrEmpty()));
        }

        public void Range(int low, int high)
        {
            if (Length > high) throw new InvalidDataException("Value entered is too big");
            if (Input.Length > high) throw new InvalidDataException("String entered exceeds character limit");
            if (Length < low) throw new InvalidDataException("Value entered is too small");
            if (Input.Length < low) throw new InvalidDataException("String entered is below character limit");
        }


    }
}
