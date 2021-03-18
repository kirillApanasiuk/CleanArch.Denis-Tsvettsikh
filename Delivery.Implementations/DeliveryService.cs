using DeliveryInterfaces;
using System;
using System.Threading.Tasks;

namespace Delivery.Implementations
{
    public class DeliveryService : IDeliveryService
    {
        public decimal CalculateDeliveryCost(double weight)
        {
            return (decimal)weight * 10;
        }

        public Task<bool> IsDeliveredAsync(int orderId)
        {
            return Task.FromResult(true);
        }
    }
}
