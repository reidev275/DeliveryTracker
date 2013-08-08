using DapperQueryExecutor;
using DeliveryTracker.Models;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryTracker.Repositories
{
	public class DapperDeliveryRepository : DapperRepository, IDeliveryRepository
	{
		public DapperDeliveryRepository(IDapperQueryExecutor queryExecutor, string connectionString)
			: base(queryExecutor, connectionString) {  }
		
		public IEnumerable<Delivery> GetByTruck(int truck)
		{
			var query = new DapperQuery(ConnectionString)
			{
				Sql = "SELECT" + _deliveryFields + @"
						FROM Delivery with (NOLOCK) 
						WHERE [Truck] = @Truck 
						AND [Completed] is null",
				Parameters = new { Truck = truck }
			};
			var deliveries = QueryExecutor.Query<Delivery>(query);

			foreach (var delivery in deliveries)
			{
				delivery.Items = GetItemsForDelivery(delivery.Id);
			}

			return deliveries;
		}

		public Delivery GetById(int id)
		{
			var query = new DapperQuery(ConnectionString)
			{
				Sql = "SELECT" + _deliveryFields + @"
						FROM Delivery with (NOLOCK) 
						WHERE [Id] = @Id",
				Parameters = new { Id = id }
			};
			var delivery = QueryExecutor.Query<Delivery>(query).FirstOrDefault();
			if (delivery == null) return null;
			delivery.Items = GetItemsForDelivery(delivery.Id);
			return delivery;
		}

		public Delivery Complete(Delivery delivery)
		{
			var query = new DapperQuery(ConnectionString)
			{
				Sql = @"UPDATE [Delivery] 
						SET [Signature] = @Signature,
							[Printed] = @Printed,
							[Completed] = GetDate()
						WHERE [Id] = @Id",
				Parameters = new { Id = delivery.Id }
			};
			QueryExecutor.Execute(query);
			return GetById(delivery.Id);
		}

		public Delivery Insert(Delivery delivery)
		{

			throw new System.NotImplementedException();
		}

		private IEnumerable<Item> GetItemsForDelivery(int deliveryId)
		{
			var query = new DapperQuery(ConnectionString)
			{
				Sql = "SELECT" + _itemFields + "FROM [DeliveryItem] with (NOLOCK) where [DeliveryId] = @DeliveryId",
				Parameters = new { DeliveryId = deliveryId }
			};
			return QueryExecutor.Query<Item>(query);
		}

		static string _deliveryFields = " [Id], [Number], [Date], [SeqNum], [DeliveryDate], [Company], [Salesman], [Addr1], [Addr2], [City], [State], [Zip], [Phone], [Contact], [PoNumber], [Signature], [Truck], [Completed], [Printed] ";
		static string _itemFields = " [Id], [Number], [Description], [Allocated], [Delivered], [UnitOfMeasure] ";
	}
}