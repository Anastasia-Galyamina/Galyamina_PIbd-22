﻿namespace ComputerShopFileImplement.Models
{
    public class WarehouseComponent
    {
        public int Id { get; set; }

        public int WarehouseId { get; set; }

        public int ComponentId { get; set; }

        public int Count { get; set; }
    }
}
