using System.ComponentModel;

namespace ComputerWorkShopBusinessLogic.ViewModels
{
    public class ComputerComponentViewModel
    {
        public int Id { get; set; }

        public int ComputerId { get; set; }

        public int ComponentId { get; set; }

        [DisplayName("Компонент")]
        public string ComponentName { get; set; }

        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
