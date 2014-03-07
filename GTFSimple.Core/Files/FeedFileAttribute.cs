using System;

namespace GTFSimple.Core.Files
{
    internal class FeedFileAttribute : Attribute
    {
        private readonly string fileName;

        public FeedFileAttribute(string fileName)
        {
            this.fileName = fileName;
        }

        public string FileName
        {
            get { return fileName; }
        }
    }
}