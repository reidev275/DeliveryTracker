using DeliveryTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliveryTracker.Managers
{
    public class DeliveryManager : IDeliveryManager
    {
        public Models.Delivery Update(Models.Delivery delivery)
        {
            throw new NotImplementedException();
        }

        public Models.Delivery Insert(Models.Delivery delivery)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Delivery> GetByTruck(int truck)
        {
            return new List<Delivery>
            {
                new Delivery
                {
                    Company = "Kryptonite Inc.",
                    Addr1 = "9302 Ashmeade Rd.",
                    Contact = "Clark Kent",
                    Truck = truck,
                    Number = "I    1234",
                    PoNumber = "10923804",
                    City = "Knoxville",
                    State = "TN",
                    Zip = "37922",
                    Phone = "(865) 555-1122",
                    Items = new List<Item>
                    {
                        new Item
                        {
                            Number = "CTG43",
                            Description = "Countertop",
                            Allocated = 60,
                            Delivered = 60,
                            UnitOfMeasure = "IN"
                        }
                    }
                },
                new Delivery
                {
                    Company = "Art Vandalay",
                    Addr1 = "1900 Bishops Bridge Rd.",
                    Contact = "Lois Lane",
                    Truck = truck,
                    Number = "I    1235",
                    PoNumber = "AEFD-82638",
                    City = "Knoxville",
                    State = "TN",
                    Zip = "37922",
                    Phone = "(865) 555-1122",
                    Items = new List<Item>
                    {
                        new Item
                        {
                            Number = "01293",
                            Description = "Widget",
                            Allocated = 1,
                            Delivered = 1,
                            UnitOfMeasure = "EA"
                        },
                        new Item
                        {
                            Number = "203DFI-1",
                            Description = "Brushed Nickel Faucet",
                            Allocated = 2,
                            Delivered = 2,
                            UnitOfMeasure = "EA"
                        }
                    }
                }
            };
        }
    }
}