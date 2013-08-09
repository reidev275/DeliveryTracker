using DapperQueryExecutor;
using DeliveryTracker.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
							[Completed] = @Completed
						WHERE [Id] = @Id",
				Parameters = new 
				{ 
					Id = delivery.Id,
					Signature = delivery.Signature,
					Printed = delivery.Printed,
					Completed = DateTime.UtcNow
				}
			};
			QueryExecutor.Execute(query);
			foreach (var item in delivery.Items)
			{
				SaveDeliveredQty(item);		
			}
			return GetById(delivery.Id);
		}

		public Delivery Insert(Delivery delivery)
		{
			using (var conn = new SqlConnection(ConnectionString))
			using (var cmd = conn.CreateCommand())
			{
				cmd.CommandText = @"INSERT INTO [Delivery]
						([Number],[SeqNum],[Company],[Salesman],[Addr1],[Addr2],[City],[State],[Zip],[Phone],[Contact],[PoNumber],[Truck])	Values
						(@Number, @SeqNum, @Company, @Salesman, @Addr1, @Addr2, @City, @State, @Zip, @Phone, @Contact, @PoNumber, @Truck)
						select SCOPE_IDENTITY()";
				cmd.Parameters.AddWithValue("@Number", delivery.Number);
				cmd.Parameters.AddWithValue("@SeqNum", delivery.SeqNum);
				cmd.Parameters.AddWithValue("@Company", delivery.Company);
				cmd.Parameters.AddWithValue("@Salesman", delivery.Salesman);
				cmd.Parameters.AddWithValue("@Addr1", delivery.Addr1);
				cmd.Parameters.AddWithValue("@Addr2", delivery.Addr2 ?? "");
				cmd.Parameters.AddWithValue("@City", delivery.City);
				cmd.Parameters.AddWithValue("@State", delivery.State);
				cmd.Parameters.AddWithValue("@Zip", delivery.Zip);
				cmd.Parameters.AddWithValue("@Phone", delivery.Phone);
				cmd.Parameters.AddWithValue("@Contact", delivery.Contact);
				cmd.Parameters.AddWithValue("@PoNumber", delivery.PoNumber);
				cmd.Parameters.AddWithValue("@Truck", delivery.Truck);

				conn.Open();
				delivery.Id = Convert.ToInt32(cmd.ExecuteScalar());
			}

			InsertItems(delivery.Items, delivery.Id);

			return delivery;
		}

		private void InsertItems(IEnumerable<Item> items, int deliveryId)
		{
			using (var conn = new SqlConnection(ConnectionString))
			{
				conn.Open();
				foreach (var item in items)
				{
					using (var cmd = conn.CreateCommand())
					{
						cmd.CommandText = @"INSERT INTO [DeliveryItem]
								([DeliveryId],[Number],[Description],[Allocated],[Delivered],[UnitOfMeasure],[Line]) Values
								(@DeliveryId, @Number, @Description, @Allocated, @Delivered, @UnitOfMeasure, @Line)
								select SCOPE_IDENTITY()";
						cmd.Parameters.AddWithValue("@DeliveryId", deliveryId);
						cmd.Parameters.AddWithValue("@Number", item.Number);
						cmd.Parameters.AddWithValue("@Description", item.Description);
						cmd.Parameters.AddWithValue("@Allocated", item.Allocated);
						cmd.Parameters.AddWithValue("@Delivered", item.Delivered);
						cmd.Parameters.AddWithValue("@UnitOfMeasure", item.UnitOfMeasure);
						cmd.Parameters.AddWithValue("@Line", item.Line);
					
						item.Id = Convert.ToInt32(cmd.ExecuteScalar());
					}
				}
			}
		}

		private void SaveDeliveredQty(Item item)
		{
			var query = new DapperQuery(ConnectionString)
			{
				Sql = @"UPDATE [DeliveryItem] 
						SET [Delivered] = @Delivered
						WHERE [Id] = @Id",
				Parameters = new 
				{ 
					Id = item.Id,
					Delivered = item.Delivered
				}
			};
			QueryExecutor.Execute(query);
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

		static string _deliveryFields = " [Id], [Number],[SeqNum], [Company], [Salesman], [Addr1], [Addr2], [City], [State], [Zip], [Phone], [Contact], [PoNumber], [Signature], [Truck], [Completed], [Printed] ";
		static string _itemFields = " [Id], [Number], [Description], [Allocated], [Delivered], [UnitOfMeasure] ";
	}
}