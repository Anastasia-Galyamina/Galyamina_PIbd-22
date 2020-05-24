using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComputerWorkShopDatabaseImplement.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Required]
        public string ClientFIO { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
