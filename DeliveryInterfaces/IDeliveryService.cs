using System;
using System.Threading.Tasks;

namespace DeliveryInterfaces
{
    public interface IDeliveryService
    {
        decimal CalculateDeliveryCost(double weight);
        Task<bool> IsDeliveredAsync(int orderId);
    }
}
