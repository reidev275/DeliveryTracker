using DeliveryTracker.Models;
using System.Collections.Generic;

namespace DeliveryTracker.Managers
{
    public interface IDeliveryManager
    {
        Delivery Update(int id, Delivery delivery);
        Delivery Insert(Delivery delivery);
        IEnumerable<Delivery> GetByTruck(int truck);
    }
}
