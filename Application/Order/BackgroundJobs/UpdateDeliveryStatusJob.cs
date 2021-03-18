using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interface;
using DeliveryInterfaces;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Mobile.UseCases.Order.BackgroundJobs
{
    public class UpdateDeliveryStatusJob:IJob
    {
        private readonly IDbContext _dbContext;
        private readonly IDeliveryService _deliveryService;

        public UpdateDeliveryStatusJob(IDbContext dbContext,IDeliveryService deliveryService)
        {
            _dbContext = dbContext;
            _deliveryService = deliveryService;
        }

        public async Task ExecuteAsync()
        {
            var orders =await  _dbContext.Orders
                .Where(o => o.Status == OrderStatus.Created)
                .ToListAsync();

          var items=  orders.Select(x => new
            {
                Order = x,
                Task = _deliveryService.IsDeliveredAsync(x.Id)
            }).ToList();

          await Task.WhenAll(items.Select(x => x.Task));

          foreach (var item in items)
          {
              if (item.Task.Result)
              {
                  item.Order.Status = OrderStatus.Delivered;
              }
          }

          await _dbContext.SaveChangesAsync();

        }
    }
}
