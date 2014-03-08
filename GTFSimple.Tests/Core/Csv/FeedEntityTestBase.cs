using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using NUnit.Framework;

namespace GTFSimple.Tests.Core.Csv
{
    public class FeedEntityTestBase
    {
        protected static void AssertCsvRow<T>(T entity, string expected) where T : class
        {
            var sb = new StringBuilder();
            using (var csvWriter = new CsvWriter(new StringWriter(sb)))
            {
                csvWriter.WriteRecord(entity);
            }

            var actual = sb.ToString();
            Assert.AreEqual(expected + Environment.NewLine, actual);

            //using (var csvReader = CsvReader<T>(actual))
            //{
            //    Assert.True(csvReader.Read());
            //    var record = csvReader.GetRecord<T>();
            //    Assert.NotNull(record);
            //}
        }

        //private static CsvReader CsvReader<T>(string actual) where T : class
        //{
        //    return new CsvReader(new StringReader(actual))
        //    {
        //        Configuration = { HasHeaderRecord = false },
        //    };
        //}

        protected static void AssertCsvRows<T>(IEnumerable<T> entities, params string[] expected) where T : class
        {
            var pairs = entities.Zip(expected, (entity, csv) => new { entity, csv });
            foreach (var p in pairs)
                AssertCsvRow(p.entity, p.csv);
        }

        protected static void AssertHeader<T>(string expected) where T : class
        {
            var sb = new StringBuilder();
            using (var csvWriter = new CsvWriter(new StringWriter(sb)))
            {
                csvWriter.WriteHeader<T>();
            }

            Assert.AreEqual(expected + Environment.NewLine, sb.ToString());
        }
    }
}