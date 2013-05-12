using System;
using System.IO;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using GTFSimple.Core.Export;

namespace GTFSimple.Tests
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void TestCase()
        {
            var writer = new FeedFileWriter();

            writer.Write("calendar", "Calendar.txt");
        }
    }
}

