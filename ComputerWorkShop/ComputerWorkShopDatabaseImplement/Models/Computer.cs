using ComputerWorkShopDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ComputerWorkShoprDatabaseImplement.Models
{
    public class Computer
    {
        public int Id { get; set; }
        [Required]
        public string ComputerName { get; set; }
        [Required]
        public decimal Price { get; set; }
        public virtual List<ComputerComponent> ComputerComponents { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
