using Domain.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public OrderStatus Status { get; set; }
        public ICollection<OrderItem> Items { get; set; }
    }
}
