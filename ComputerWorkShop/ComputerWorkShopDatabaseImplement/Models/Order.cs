﻿using ComputerWorkShopBusinessLogic.Enums;
using ComputerWorkShoprDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputerWorkShopDatabaseImplement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ComputerId { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public decimal Sum { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public virtual Computer Computer { get; set; }
    }
}
