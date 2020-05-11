using ComputerWorkShopBusinessLogic.Enums;
using System;

namespace ComputerWorkShopBusinessLogic.ViewModels
{
    public class ReportOrdersViewModel
    {        
        public DateTime DateCreate { get; set; }
        public string ComputerName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
    }
}
