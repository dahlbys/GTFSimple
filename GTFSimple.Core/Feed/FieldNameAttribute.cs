using System;

namespace GTFSimple.Core.Feed
{
    public class FieldNameAttribute : Attribute
    {
        public FieldNameAttribute(string fieldName)
        {
            FieldName = fieldName;
        }
        
        public string FieldName { get; private set; }
    }
}

