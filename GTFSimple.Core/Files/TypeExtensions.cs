using System;
using System.Linq;

namespace GTFSimple.Core.Files
{
    public static class TypeExtensions
    {
        public static string FeedFile(this Type type)
        {
            var attr = (FeedFileAttribute)type.GetCustomAttributes(typeof(FeedFileAttribute), false).FirstOrDefault();
            return attr == null ? null : attr.FileName;
        }
    }
}