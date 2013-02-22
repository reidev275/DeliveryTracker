using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliveryTracker.Models
{
	public class Delivery
	{
        public int Id { get; set; }
		public string Number { get; set; }
        public DateTime Date { get; set; }
        public int SeqNum { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Company { get; set; }
        public string Salesman { get; set; }
		public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Contact { get; set; }
        public string PoNumber { get; set; }
		public string Signature { get; set; }
		public int Truck { get; set; }
        public DateTime? Completed { get; set; }

		public IEnumerable<Item> Items { get; set; }

		//public IEnumerable<Point> Points { get; set; }
		//public IEnumerable<int> Penups { get; set; }
	}

	public class Item
	{
		public string Number { get; set; }
		public string Description { get; set; }
		public double Allocated { get; set; }
		public double Delivered { get; set; }
		public string UnitOfMeasure { get; set; }
        public string LineNumber { get; set; }
	}
}