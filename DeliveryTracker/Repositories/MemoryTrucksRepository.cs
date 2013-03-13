using System.Collections.Generic;

namespace DeliveryTracker.Repositories
{
    public class MemoryTrucksRepository : ITrucksRepository
    {
        static IEnumerable<int> _trucks = new[] {
            1,2,3,4
        };

        public IEnumerable<int> GetAll()
        {
            return _trucks;
        }
    }
}