﻿using MyStore.Domain.Entities.Orders;
using System;

namespace MyStore.Application.Services.Orders.Queries.GetOrdersForAdmin
{
    public class OrdersDto
    {
        public long OrderId { get; set; }
        public DateTime InsetTime { get; set; }
        public long RequestId { get; set; }
        public long UserId { get; set; }
        public OrderState OrderState { get; set; }
        public int ProductCount { get; set; }

    }
}
