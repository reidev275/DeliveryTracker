using System.Collections.Generic;
using System.Linq;

namespace DeliveryTracker.Filters
{
    public static class ApiExtensions
    {
        public static string GetValue(this System.Net.Http.Headers.HttpRequestHeaders obj, string key)
        {
            IEnumerable<string> enumerableHeader;
            obj.TryGetValues(key, out enumerableHeader);

            if (enumerableHeader == null) return null;

            var list = enumerableHeader as IList<string> ?? enumerableHeader.ToList();
            if (list.Count == 0) return null;

            return list.First();
        }
    }
}