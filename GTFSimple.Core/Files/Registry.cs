using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GTFSimple.Core.Files
{
    public class Registry : IEnumerable<KeyValuePair<string, Type>>
    {
        private readonly IDictionary<string, Type> lookup;

        public Registry()
        {
            var fileTypes = from type in GetType().Assembly.GetTypes()
                            let file = type.FeedFile()
                            where file != null
                            select new { type, file };

            lookup = fileTypes.ToDictionary(x => x.file, x => x.type);
        }

        public virtual Type this[string fileName]
        {
            get { return lookup[fileName]; }
        }

        public IEnumerator<KeyValuePair<string, Type>> GetEnumerator()
        {
            return lookup.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public string FileName(Type type)
        {
            return type.FeedFile() + ".txt";
        }
    }
}