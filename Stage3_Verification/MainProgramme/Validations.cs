using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;

namespace CsvFileConverter
{
    public class Validations : IValidations
    {
        private readonly Dictionary<Type, IFieldValidator> _validators;

        public Validations(IEnumerable<IFieldValidator> validators)
        {
            _validators = validators?.ToDictionary(m => m.TypeToValidate) ??
                          throw new ArgumentNullException(nameof(validators));
        }

        public DealData[] ValidateData(DealData[] rows)
        {
            Log.Logger.Information(rows[0].ToString());
            return null;
        }
    }
}