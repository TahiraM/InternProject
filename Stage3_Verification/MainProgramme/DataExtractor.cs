using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using FluentValidation;
using NHibernate.Linq;
using Serilog;

namespace CsvFileConverter
{
    public class DataExtractor : IDataExtractor
    {
        private readonly IEnumerable<IFieldValidator> _validators;
        private readonly ILogger _logger;

        public DataExtractor(IEnumerable<IFieldValidator> validators, ILogger logger)
        {
            _validators = validators ?? throw new ArgumentNullException(nameof(validators));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public DealData[] ReadContent(StringReader reader, bool headerPresent)
        {
            var config = new Configuration
            {
                Delimiter = "||",
                Encoding = Encoding.UTF8,
                HasHeaderRecord = headerPresent,
                QuoteNoFields = false,
                PrepareHeaderForMatch = header => header.ToLowerInvariant().Replace(" ", string.Empty)
            };

            try
            {
                using (var csv = new CsvReader(reader, config))
                {
                    var classMap = new DealDataMap(_validators);
                    csv.Configuration.RegisterClassMap(classMap);
                    var dealDatas = csv.GetRecords<DealData>().ToArray();

                    _logger.Information($"CSV DATA OUT! with {dealDatas.Length} records");

                    return dealDatas;
                }
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);

                throw;
            }
        }

        //private DealData[] MapDataToDealData(DealDataRaw[] dealDataRaws)
        //{
            
        //        return dealDataRaws.Select(m => new DealDataRawValidator())
        //        {
                    


        //        }).ToArray();
            
        //}
    }
}

//return dealDataRaws.Select(m => new DealData()
//{
//V3CompanyId = Convert.ToString(m.V3CompanyId),
//V3CompanyName = Convert.ToString(m.V3CompanyName),
//V3DealId = Convert.ToString(m.V3DealId),
//EFrontDealId = Convert.ToString(m.EFrontDealId),
//DealName = Convert.ToString(m.DealName),
//Sector = Convert.ToString(m.Sector),
//Country = Convert.ToString(m.Country),
//TransactionType = Convert.ToString(m.TransactionType),
//ActiveInActive = Convert.ToString(m.ActiveInActive),
//OtherFees = Convert.ToDouble(m.OtherFees),
//SectorId = Convert.ToInt32(m.SectorId),
//CountryId = Convert.ToInt32(m.CountryId),
//TransactionTypeId = Convert.ToInt32(m.TransactionTypeId),
//TransactionFees = Convert.ToDouble(m.TransactionFees),
//ExitDate = Convert.ToDateTime(m.ExitDate)


//}).ToArray();