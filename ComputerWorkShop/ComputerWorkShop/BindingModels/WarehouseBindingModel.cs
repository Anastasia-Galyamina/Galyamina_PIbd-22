using System.Collections.Generic;

namespace ComputerWorkShopBusinessLogic.BindingModels
{
    public class WarehouseBindingModel
    {
        public int? Id { get; set; }
        public string WarehouseName { get; set; }        
        public Dictionary<int, (string, int)> WarehouseComponents { get; set; }
    }
}
