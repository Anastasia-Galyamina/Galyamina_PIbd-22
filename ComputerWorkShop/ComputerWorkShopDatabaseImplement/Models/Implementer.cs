﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerWorkShopDatabaseImplement.Models
{
    public class Implementer
    {
        public int Id { get; set; }
        [Required]
        public string ImplementerFIO { get; set; }
        public int WorkingTime { get; set; }
        public int PauseTime { get; set; }
        [ForeignKey("ImplementerId")]
        public virtual List<Order> Orders { get; set; }
    }
}
