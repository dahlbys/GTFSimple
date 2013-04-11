using System;
using System.IO;
using System.Diagnostics;
using System.Linq;
using GTFSimple.Core.Feed;

namespace GTFSimple.Core.Export
{
    public class FeedFileWriter
    {
        public void Write(string feedFile, string filePath)
        {
            if (String.Equals(feedFile, "agency", StringComparison.OrdinalIgnoreCase))
                CreateAgency(feedFile, filePath);
        }

        private static void CreateAgency(string feedFile, string filePath)
        {
            var crtagency = new Agency();
            crtagency.Id = "cr_transit";
            crtagency.Name = "CR Transit";
            crtagency.Url = new Uri("http://www.cedar-rapids.org/resident-resources/Transit/Pages/default.aspx");
            crtagency.TimeZone = TimeZoneInfo.Local; //TimeZoneInfo.FindSystemTimeZoneById();
            crtagency.Language = "en";
            crtagency.Phone = "319-286-5573";
            crtagency.FareUrl = new Uri("http://www.cedar-rapids.org/resident-resources/Transit/fares/Pages/default.aspx");

            var header = CreateHeader(crtagency.GetType());
            
            var t = crtagency.GetType();
            var data = string.Join(",",
                                   from p in t.GetProperties()
                                   select p.GetValue(crtagency, null)
                                   );
            Debug.WriteLine(data);
            
            File.WriteAllLines(filePath, new []{header, data});
        }

        private static string CreateHeader(Type feedFileType)
        {
            var t = feedFileType;
            
            var header = string.Join(",",
                                     from p in t.GetProperties()
                                     let fieldName = p.GetCustomAttributes(typeof(FieldNameAttribute), false).Cast<FieldNameAttribute>().First()
                                     where fieldName != null
                                     select fieldName.FieldName
                                     );
            
            Debug.WriteLine(header);

            return header;
        }
    }
}

