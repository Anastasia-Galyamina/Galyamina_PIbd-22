namespace ComputerWorkShopBusinessLogic.BindingModels
{
    public class WarehouseComponentBindingModel
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int ComponentId { get; set; }
        public int Count { get; set; }
    }
}
