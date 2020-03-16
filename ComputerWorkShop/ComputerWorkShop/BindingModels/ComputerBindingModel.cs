using System.Collections.Generic;

namespace ComputerWorkShopBusinessLogic.BindingModels
{
    public class ComputerBindingModel
    {
        public int? Id { get; set; }
        public string ComputerName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> ComputerComponents { get; set; }
    }
}
