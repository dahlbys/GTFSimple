using CsvHelper.Configuration;

namespace GTFSimple.Core.Feed
{
    internal class FieldNameAttribute : CsvFieldAttribute
    {
        public FieldNameAttribute()
        {
        }

        public FieldNameAttribute(string fieldName)
        {
            Name = fieldName;
        }
    }
}