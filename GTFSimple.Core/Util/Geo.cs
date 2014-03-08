using System;

namespace GTFSimple.Core.Util
{
    public static class Geo
    {
        /// <remarks>
        /// Source: http://megocode3.wordpress.com/2008/02/05/haversine-formula-in-c/
        /// </remarks>
        public static double Distance(ILocation left, ILocation right)
        {
            if (left == null || right == null)
                return 0f;

            var lLat = ToRadian(left.Latitude);
            var rLat = ToRadian(right.Latitude);

            var dLat = rLat - lLat;
            var dLon = ToRadian(right.Longitude - left.Longitude);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(lLat) * Math.Cos(rLat) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            return 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
        }

        private static double ToRadian(double val)
        {
            return (Math.PI / 180) * val;
        }
    }

    public interface ILocation
    {
        double Latitude { get; }
        double Longitude { get; }
    }
}