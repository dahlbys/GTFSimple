using CsvHelper.Configuration;

namespace GTFSimple.Core.Csv
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