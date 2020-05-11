using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComputerWorkShopDatabaseImplement.Models
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
