using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class OrderItem
    {
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
