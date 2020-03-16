using System.Collections.Generic;

namespace ComputerWorkShopBusinessLogic.BindingModels
{
    public class ComputerBindingModel
    {
        public int Id { get; set; }
        public string ComputerName { get; set; }
        public decimal Price { get; set; }
        public List<ComputerComponentBindingModel> ComputerComponents { get; set; }
    }
}
