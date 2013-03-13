using System.Collections.Generic;

namespace DeliveryTracker.Repositories
{
    public interface ITrucksRepository
    {
        IEnumerable<int> GetAll();
    }
}
