﻿using DeliveryTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliveryTracker.Repositories
{
	public class MemoryDeliveryRepository : IDeliveryRepository
	{
		private static readonly List<Delivery> _repo = new List<Delivery>
			{
				new Delivery
				{
					Company = "Kryptonite Inc.",
					Addr1 = "9302 Ashmeade Rd.",
					Contact = "Clark Kent",
					Truck = 1,
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
					Company = "Luther Industries",
					Addr1 = "1900 Bishops Bridge Rd.",
					Contact = "Lois Lane",
					Truck = 1,
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
				},
				new Delivery
				{
					Company = "Wayne Enterprises",
					Addr1 = "1902 Bishops Bridge Rd.",
					Contact = "Bruce Wayne",
					Truck = 2,
					Number = "I    1236",
					PoNumber = "Classified1",
					City = "Knoxville",
					State = "TN",
					Zip = "37922",
					Phone = "(865) 555-1123",
					Items = new List<Item>
					{
						new Item
						{
							Number = "5s9fs-5",
							Description = "Tumbler",
							Allocated = 1,
							Delivered = 1,
							UnitOfMeasure = "EA"
						},
						new Item
						{
							Number = "9fwe8w34",
							Description = "Bat Wing",
							Allocated = 1,
							Delivered = 1,
							UnitOfMeasure = "EA"
						}
					}
				}
			};


		public IEnumerable<Delivery> GetByTruck(int truck)
		{
			return _repo.Where(x => x.Truck == truck);
		}
	}
}