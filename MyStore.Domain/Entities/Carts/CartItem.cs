﻿using MyStore.Domain.Entities.Commons;
using MyStore.Domain.Entities.Products;

namespace MyStore.Domain.Entities.Carts
{
    public class CartItem:BaseEntity
    {
        public virtual  Product Product { get; set; }
        public long ProductId { get; set; }

        public int Count { get; set; }
        public int  Price { get; set; }

        public virtual Cart Cart { get; set; }
        public long CartId { get; set; }
    }
}
