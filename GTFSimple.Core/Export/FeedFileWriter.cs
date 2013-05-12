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
            else if (String.Equals(feedFile, "calendar", StringComparison.OrdinalIgnoreCase))
                CreateCalendar(feedFile, filePath);
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

        private static void CreateCalendar(string feedFile, string filePath)
        {
            var crtcalendarWD = new Calendar();
            crtcalendarWD.ServiceId = "WD";
            crtcalendarWD.Monday = true;
            crtcalendarWD.Tuesday = true;
            crtcalendarWD.Wednesday = true;
            crtcalendarWD.Thursday = true;
            crtcalendarWD.Friday = true;
            crtcalendarWD.Saturday = false;
            crtcalendarWD.Sunday = false;
            crtcalendarWD.StartDate = new DateTime(2012, 01, 01);
            crtcalendarWD.EndDate = new DateTime(2013, 12, 31);

            var crtcalendarWE = new Calendar();
            crtcalendarWE.ServiceId = "WE";
            crtcalendarWE.Monday = false;
            crtcalendarWE.Tuesday = false;
            crtcalendarWE.Wednesday = false;
            crtcalendarWE.Thursday = false;
            crtcalendarWE.Friday = false;
            crtcalendarWE.Saturday = true;
            crtcalendarWE.Sunday = false;
            crtcalendarWE.StartDate = new DateTime(2012, 01, 01);
            crtcalendarWE.EndDate = new DateTime(2013, 12, 31);
            
            var header = CreateHeader(crtcalendarWD.GetType());
            
            var t1 = crtcalendarWD.GetType();
            var data1 = string.Join(",",
                                   from p in t1.GetProperties()
                                   select p.GetValue(crtcalendarWD, null)
                                   );

            var t2 = crtcalendarWE.GetType();
            var data2 = string.Join(",",
                                   from p in t2.GetProperties()
                                   select p.GetValue(crtcalendarWE, null)
                                   );
            Debug.WriteLine(data1);
            
            File.WriteAllLines(filePath, new []{header, data1, data2});
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

