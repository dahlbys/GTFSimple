using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GTFSimple.Core.Util
{
    public static class EnumerableExtensions
    {
        /// <remarks>
        /// Source: http://ideone.com/8l0LH
        /// </remarks>
        public static IEnumerable<IGrouping<T, T>> GroupByCluster<T>(this IEnumerable<T> source,
                                                                     Func<T, T, double> distance, double eps)
        {
            var result = new HashSet<ClusterGrouping<T>>();
            foreach (var t in source)
            {
                // need to materialize, as we are changing the result
                var containingGroups = result.Where(g => g.Any(gt => distance(t, gt) < eps)).ToList();
                switch (containingGroups.Count)
                {
                    case 0:
                        result.Add(new ClusterGrouping<T>(t));
                        break;
                    case 1:
                        containingGroups[0].Include(t);
                        break;
                    default:
                        result.Add(new ClusterGrouping<T>(containingGroups));
                        foreach (var g in containingGroups)
                            result.Remove(g);
                        break;
                }
            }
            return result;
        }

        private class ClusterGrouping<T> : IGrouping<T, T>
        {
            private readonly List<T> items = new List<T>();

            internal ClusterGrouping(T t)
            {
                Key = t;
                items.Add(t);
            }

            internal ClusterGrouping(IList<ClusterGrouping<T>> containingGroups)
            {
                Key = containingGroups[0].Key;
                items.AddRange(containingGroups.SelectMany(g => g));
            }

            public T Key { get; private set; }

            public IEnumerator<T> GetEnumerator()
            {
                return items.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            internal void Include(T t)
            {
                items.Add(t);
            }
        }
    }
}