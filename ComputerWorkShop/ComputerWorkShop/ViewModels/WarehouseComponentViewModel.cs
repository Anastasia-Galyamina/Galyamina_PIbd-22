using System.ComponentModel;


namespace ComputerWorkShop.ViewModels
{
    public class WarehouseComponentViewModel
    {
        public int Id { get; set; }

        public int WarehouseId { get; set; }

        public int ComponentId { get; set; }

        [DisplayName("Компонент")]
        public string ComponentName { get; set; }

        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
