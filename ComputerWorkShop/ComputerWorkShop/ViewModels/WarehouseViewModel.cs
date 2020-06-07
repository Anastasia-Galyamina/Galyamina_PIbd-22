using ComputerWorkShop.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;

namespace ComputerWorkShopBusinessLogic.ViewModels
{
    public class WarehouseViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название склада")]
        public string WarehouseName { get; set; }
        public List<WarehouseComponentViewModel> WarehouseComponents { get; set; }
    }
}
