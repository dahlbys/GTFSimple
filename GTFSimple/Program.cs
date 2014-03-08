using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using GTFSimple.Core.Feed;
using GTFSimple.Core.Files;
using GTFSimple.Core.Generators;
using GTFSimple.Core.Input;

namespace GTFSimple
{
    class Program
    {
        private static readonly Registry registry = new Registry();

        private static readonly StopGenerator stopGenerator =
            new StopGenerator(0.000001, new SequentialStopIdGenerator(3));

        private static readonly StopTimeGenerator stopTimeGenerator = new StopTimeGenerator();

        private static readonly TripGenerator tripGenerator = new TripGenerator();

        static void Main(string[] args)
        {
            var srcDir = args.Length < 1 ? "." : args[0];
            var destDir = args.Length < 2
                              ? Path.Combine(srcDir, DateTime.Now.ToString("'feed'_yyyy-MM-dd_HH-mm-ss"))
                              : args[1];

            Console.WriteLine("Reading from {0}...", srcDir);

            var src = new DirectoryInfo(srcDir);

            var files = from feedFile in registry
                        let type = feedFile.Value
                        from file in src.GetFiles(feedFile.Key + ".*")
                        let values = ReadCsv(type, file)
                        select new
                        {
                            File = file,
                            Type = feedFile.Value,
                            Values = values,
                        };

            var fileLookup = files.ToDictionary(f => f.Type, f => f.Values);

            foreach (var f in fileLookup)
            {
                Console.WriteLine(f.Key.Name);
                foreach (var v in f.Value)
                    Console.WriteLine("  " + v);
            }

            var routeStops = stopGenerator.Generate(fileLookup[typeof(RouteStop)].Cast<RouteStop>());
            Console.WriteLine(typeof(Stop).Name);
            var stops = routeStops.ToLookup(x => x.Value, x => x.Key);
            foreach (var stop in stops.OrderByDescending(g => g.Count()))
            {
                Console.WriteLine("  " + stop.Key);
                foreach (var rs in stop)
                    Console.WriteLine("    " + rs);
            }

            var tripTimes = tripGenerator.Generate(fileLookup[typeof(TripTime)].Cast<TripTime>(), "{0}-{1}-{2:00}");
            Console.WriteLine(typeof(Trip).Name);

            foreach (var trip in tripTimes.Values)
            {
                Console.WriteLine("  " + trip);
            }

            var stopTimes = stopTimeGenerator.Generate(routeStops, tripTimes).ToList();
            Console.WriteLine(typeof(StopTime).Name);
            foreach (var stopTime in stopTimes)
            {
                Console.WriteLine("  " + stopTime);
            }

            Console.WriteLine("Writing to {0}...", destDir);
            if (!Directory.Exists(destDir))
                Directory.CreateDirectory(destDir);

            //foreach (var feedFile in fileLookup)
            //    if (feedFile.Key.Namespace == typeof(FeedInfo).Namespace)
            //        WriteCsv(destDir, feedFile.Key, feedFile.Value);

            WriteCsv<Agency>(destDir, fileLookup);
            WriteCsv<CalendarDate>(destDir, fileLookup);
            WriteCsv<Calendar>(destDir, fileLookup);
            WriteCsv<FareAttributes>(destDir, fileLookup);
            WriteCsv<FareRules>(destDir, fileLookup);
            WriteCsv<FeedInfo>(destDir, fileLookup);
            WriteCsv<Frequency>(destDir, fileLookup);
            WriteCsv<Route>(destDir, fileLookup);
            WriteCsv<Shape>(destDir, fileLookup);
            WriteCsv(destDir, stops.Select(s => s.Key).OrderBy(s => s.Id));
            WriteCsv(destDir, stopTimes);
            WriteCsv<Transfer>(destDir, fileLookup);
            WriteCsv(destDir, tripTimes.Values.OrderBy(t => t.Id));
        }

        private static void WriteCsv<T>(string destDir, Dictionary<Type, IEnumerable<object>> fileLookup) where T : class
        {
            IEnumerable<object> records;
            if (fileLookup.TryGetValue(typeof(T), out records))
                WriteCsv(destDir, records.Cast<T>());
        }

        private static IEnumerable<object> ReadCsv(Type type, FileInfo file)
        {
            using (var fileReader = new StreamReader(file.OpenRead()))
            using (var csvReader = new CsvReader(fileReader))
                return csvReader.GetRecords(type).ToList();
        }

        private static void WriteCsv<T>(string destDir, IEnumerable<T> records) where T : class
        {
            var destPath = Path.Combine(destDir, registry.FileName(typeof(T)));
            using (var fileWriter = new StreamWriter(File.OpenWrite(destPath)))
            using (var csvWriter = new CsvWriter(fileWriter))
                csvWriter.WriteRecords(records);
        }

        private static void WriteCsv(string destDir, Type type, IEnumerable<object> records)
        {
            var destPath = Path.Combine(destDir, registry.FileName(type));
            using (var fileWriter = new StreamWriter(File.OpenWrite(destPath)))
            using (var csvWriter = new CsvWriter(fileWriter))
                csvWriter.WriteRecords(type, records);
        }
    }
}
