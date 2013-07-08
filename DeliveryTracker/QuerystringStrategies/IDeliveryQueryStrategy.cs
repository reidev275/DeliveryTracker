using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliveryTracker.QuerystringStrategies
{
    public interface IDeliveryQueryStrategy
    {
        void Apply(string queryString);
    }
}
