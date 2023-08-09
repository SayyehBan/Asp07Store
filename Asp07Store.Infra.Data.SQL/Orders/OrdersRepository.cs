using Asp07Store.ShopUI.Models.Interface;

namespace Asp07Store.ShopUI.Models.Repository
{
    public class OrdersRepository : IOrders
    {
        private readonly StoreDbContext storeDbContext;

        public OrdersRepository(StoreDbContext storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }
        public void Save(Order order)
        {
            storeDbContext.AttachRange(order.orderDetails.Select(d => d.Product));
            storeDbContext.Orders.Add(order);
            storeDbContext.SaveChanges();
        }
    }
}
