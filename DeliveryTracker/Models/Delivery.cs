using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliveryTracker.Models
{
	public class Delivery
	{
		public string Number { get; set; }
		public string Address { get; set; }
		public DateTime Ordered { get; set; }
		public string Signature { get; set; }
		public string Driver { get; set; }

		public IEnumerable<Item> Items { get; set; }

		//public IEnumerable<Point> Points { get; set; }
		//public IEnumerable<int> Penups { get; set; }
	}

	public class Item
	{
		public string Number { get; set; }
		public string Description { get; set; }
		public double Ordered { get; set; }
		public double Delivered { get; set; }
		public string UnitOfMeasure { get; set; }
	}
}